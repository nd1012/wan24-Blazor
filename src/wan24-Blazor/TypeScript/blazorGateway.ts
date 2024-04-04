/**
* Abstract DOM element
*/
class AbstractDomElement {
    /**
     * Assembly name
     */
    static readonly ASSEMBLY: string = 'wan24Blazor.dll';
    /**
     * Node type enumeration value name
     */
    static readonly TYPE_NODE: string = "Node";
    /**
     * Text node type enumeration value name
     */
    static readonly TYPE_TEXT: string = "Text";
    /**
     * Comment node type enumeration value name
     */
    static readonly TYPE_COMMENT: string = "Comment";
    /**
     * CDATA node type enumeration value name
     */
    static readonly TYPE_CDATA: string = "CDATA";

    /**
     * C# exports
     */
    static #_cSharpExports: any = null;

    /**
     * Element
     */
    readonly #_element: Element;
    /**
     * Type
     */
    readonly #_type: string;
    /**
     * Event listeners (key is the event name)
     */
    readonly #_eventListeners: Map<string, (e: Event) => any> = new Map<string, (e: Event) => any>();

    /**
     * Element
     */
    get element(): Element {
        return this.#_element;
    }

    /**
     * Parent index (-1, if not found)
     */
    get parentIndex(): number {
        const element: Element = this.#_element,
            parent: Element = element.parentElement;
        if (!parent) return -1;
        const childs: NodeListOf<ChildNode> = parent.childNodes,
            plen: number = childs ? childs.length : -1;
        if (!childs) return -1;
        for (let i: number = 0; i < plen; i++)
            if (childs[i] == element)
                return i;
        return -1;
    }

    /**
     * ID
     */
    get id(): string {
        return this.#_element.id;
    }

    /**
     * Parent ID
     */
    get parentId(): string {
        return this.#_element.parentElement ? this.#_element.parentElement.id : null;
    }

    /**
     * Tag
     */
    get tag(): string {
        return this.#_element.tagName;
    }

    /**
     * Type
     */
    get type(): string {
        return this.#_type;
    }

    /**
     * Attributes (key is the attribute name)
     */
    get attributes(): Map<string, string> {
        const res = new Map<string, string>(),
            attrs: NamedNodeMap = this.#_element.attributes,
            len: number = attrs ? attrs.length : 0;
        for (let i: number = 0; i < len; i++) {
            const attr: Attr = attrs[i];
            res.set(attr.name, attr.value);
        }
        return res;
    }

    /**
     * Child nodes count
     */
    get childNodesCount(): number {
        return this.#_element.childElementCount;
    }

    /**
     * Text
     */
    get text(): string {
        return this.#_element.textContent;
    }

    /**
     * If there are event listeners
     */
    get hasEventListeners(): boolean {
        return this.#_eventListeners.size > 0;
    }

    /**
     * Constructor
     * 
     * @param element DOM element
     */
    constructor(element: Element) {
        if (!element) throw new Error("Element required");
        this.#_element = ensureId(element);
        switch (element.nodeType) {
            case element.TEXT_NODE:
                this.#_type = AbstractDomElement.TYPE_TEXT;
                break;
            case element.COMMENT_NODE:
                this.#_type = AbstractDomElement.TYPE_COMMENT;
                break;
            case element.CDATA_SECTION_NODE:
                this.#_type = AbstractDomElement.TYPE_CDATA;
                break;
            default:
                this.#_type = AbstractDomElement.TYPE_NODE;
                break;
        }
    }

    /**
     * The C# exports (will throw if not initialized!)
     */
    static get cSharpExports(): any {
        if (!this.#_cSharpExports) throw new Error("Blazor gateway was not initialized");
        return this.#_cSharpExports;
    }

    /**
     * To JSON
     * 
     * @returns JSON
     */
    public toJson(): any {
        return {
            'ParentIndex': this.parentIndex,
            'ID': this.id,
            'ParentID': this.parentId,
            'Tag': this.tag,
            'Type': this.#_type,
            'Attributes': this.attributes,
            'ChildNodesCount': this.childNodesCount,
            'Text': this.text
        };
    }

    /**
     * Add an event listener
     * 
     * @param event Event name
     * @returns If added
     */
    addEventListener(event: string): boolean {
        if (this.#_eventListeners.has(event)) return false;
        const self: AbstractDomElement = this;
        this.#_eventListeners[event] = (e: Event) => AbstractDomElement.#_raiseEvent(self.id, event, e);
        this.element.addEventListener(event, this.#_eventListeners[event]);
        return true;
    }

    /**
     * Remove an event listener
     * 
     * @param event Event name
     * @returns If removed
     */
    removeEventListener(event: string): boolean {
        const existing: (e: Event) => any = this.#_eventListeners.get(event);
        if (!existing) return;
        this.#_eventListeners.delete(event);
        this.element.removeEventListener(event, existing);
        return true;
    }

    /**
     * Remove all event listeners
     */
    clearEventListeners() {
        const keys: Array<string> = Array.from<string>(this.#_eventListeners.keys()),
            len: number = keys.length;
        for (let i: number = 0; i < len; this.removeEventListener(keys[i]), i++);
    }

    /**
     * Raise an event
     * 
     * @param id ID
     * @param eventName Event name
     * @param e Event
     */
    static #_raiseEvent(id: string, eventName: string, e: Event) {
        this.cSharpExports.wan24.Blazor.DomElement.RaiseEvent(id, eventName, JSON.stringify(e));
    }

    /**
     * Initiaize
     */
    static async initAsync() {
        if (this.#_cSharpExports) return;
        const { getAssemblyExports } = await globalThis.getDotnetRuntime(0);
        this.#_cSharpExports = getAssemblyExports(this.ASSEMBLY);
    }
}

/**
 * Download stream
 */
export class DownloadStream {
    /**
     * Element
     */
    readonly #_element: HTMLAnchorElement;
    /**
     * ID
     */
    readonly #_id: string;
    /**
     * Media source
     */
    readonly #_mediaSource: MediaSource;
    /**
     * Object URL
     */
    readonly #_objectUrl: string;
    /**
     * Source buffer
     */
    readonly #_sourceBuffer: SourceBuffer;
    /**
     * Source stream
     */
    readonly #_stream: ReadableStream;
    /**
     * Stream promise
     */
    readonly #_streamPromise: PromiseLike<void>;
    /**
     * If finalized
     */
    #_isFinalized: boolean = false;

    /**
     * Constructor
     * 
     * @param fn Filename (if NULL, the download won't be started in the browser)
     * @param mime MIME type (if NULL, the default is "application/octet-stream")
     * @param stream Stream to use as data source
     */
    constructor(fn: string, mime: string = null, stream: ReadableStream = null) {
        this.#_stream = stream;
        this.#_mediaSource = new MediaSource();
        const self = this;
        this.#_mediaSource.addEventListener('sourceclose', () => self.finalize());
        this.#_objectUrl = URL.createObjectURL(this.#_mediaSource);
        this.#_sourceBuffer = this.#_mediaSource.addSourceBuffer(mime != '' ? mime : 'application/octet-stream');//TODO Send the filename here also?
        this.#_streamPromise = stream ? stream.getReader().read().then(({ done, value }) => {
            if (done) {
                self.finalize();
            } else {
                self.#_sourceBuffer.appendBuffer(value);
            }
        }) : null;
        if (fn == null) {
            this.#_element = null;
            this.#_id = generateId();
            return;
        }
        this.#_element = document.createElement('a');
        this.#_element.hidden = true;
        this.#_element.id = this.#_id = generateId();
        this.#_element.download = fn;
        this.#_element.href = this.#_objectUrl;
        this.#_element.click();
    }

    /**
     * ID
     */
    get id(): string {
        return this.#_id;
    }

    /**
     * Filename (maybe NULL)
     */
    get fileName(): string {
        return this.#_element ? this.#_element.download : null;
    }

    /**
     * If finalized
     */
    get isFinalized(): boolean {
        return this.#_isFinalized;
    }

    /**
     * The object URL
     */
    get objectUrl(): string {
        return this.#_objectUrl;
    }

    /**
     * The stream promise (maybe NULL)
     */
    get streamPromise(): PromiseLike<void> {
        return this.#_streamPromise;
    }

    /**
     * Add a data chunk to the source buffer
     * 
     * @param data base64 encoded data chunk
     */
    addDataChunk(data: string) {
        if (this.#_isFinalized) throw new Error("Finalized already");
        if (this.#_stream) throw new Error("Invalid operation");
        this.#_sourceBuffer.appendBuffer(Uint8Array.from(atob(data), c => c.charCodeAt(0)));
    }

    /**
     * Add a data chunk to the source buffer
     * 
     * @param data Data chunk
     */
    addDataChunkArray(data: Uint8Array) {
        if (this.#_isFinalized) throw new Error("Finalized already");
        if (this.#_stream) throw new Error("Invalid operation");
        this.#_sourceBuffer.appendBuffer(data);
    }

    /**
     * Finalize the download stream (no more data to send)
     * 
     * @returns If finalized
     */
    finalize(): boolean {
        if (this.#_isFinalized) return false;
        this.#_isFinalized = true;
        if (this.#_stream) this.#_stream.cancel();
        this.#_mediaSource.endOfStream();
        if (this.#_element) this.#_element.remove();
        URL.revokeObjectURL(this.#_objectUrl);
        return true;
    }
}

/**
 * DOM element settings
 */
export class DomElementSettings {
    /**
     * CSS classes
     */
    #_Class: string = null;
    /**
     * CSS style
     */
    #_Style: string = null;
    /**
     * Additional attributes
     */
    #_Attributes: Map<string, any> = null;

    /**
     * Constructor
     */
    constructor() { }

    /**
     * Get CSS classes
     */
    get Class(): string {
        return this.#_Class;
    }
    /**
     * Set CSS classes
     */
    set Class(value: string) {
        this.#_Class = value;
    }

    /**
     * Get CSS style
     */
    get Style(): string {
        return this.#_Style;
    }
    /**
     * Set CSS style
     */
    set Style(value: string) {
        this.#_Style = value;
    }

    /**
     * Get additional attributes
     */
    get Attributes(): Map<string, string> {
        return this.#_Attributes;
    }
    /**
     * Set additional attributes
     */
    set Attributes(value: Map<string, any>) {
        this.#_Attributes = value;
    }

    /**
     * Apply to a DOM element
     * 
     * @param element DOM element
     * @returns DOM element
     */
    ApplyTo(element: Element) : Element {
        if (this.Class != null) {
            const classNames = new Set<string>(),
                classes: Array<string> = this.Class.split(' '),
                len: number = classes.length;
            for (let i: number = 0, name: string; i < len; i++) {
                name = classes[i].trim();
                if (name == '') continue;
                classNames.add(name);
            }
            element.setAttribute('class', Array.from(classNames).join(' '));
        }
        if (this.Style != null) element.setAttribute('style', this.Style);
        if (this.Attributes != null) {
            const attrs: Map<string, any> = this.Attributes,
                keys: Array<string> = Array.from(attrs.keys()),
                len: number = keys.length;
            for (let i: number = 0; i < len; element.setAttribute(keys[i], attrs.get(keys[i]).toString()), i++);
        }
        return element;
    }

    /**
     * Parse from JSON
     * 
     * @param json JSON string
     * @returns DOM element settings
     */
    static FromJson(json: string): DomElementSettings {
        const res: DomElementSettings = new DomElementSettings();
        JSON.parse(json, (k, v) => {
            switch (k) {
                case 'Class':
                    res.Class = v;
                    break;
                case 'Style':
                    res.Style = v;
                    break;
                case 'Attributes':
                    res.Attributes = new Map<string, any>(v);
                    break;
                default:
                    console.warn('Unknown DOM element settings property', json, k, v);
                    break;
            }
        });
        return res;
    }
}

/**
 * Elements (required for managing event listeners; key is the ID)
 */
const Elements: Map<string, AbstractDomElement> = new Map<string, AbstractDomElement>();
/**
 * Alphabet lower and upper case characters (used for ID generation)
 */
const Alphabet: Array<string> = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".split('');
/**
 * Running download streams (key is the ID)
 */
export const DownloadStreams: Map<string, DownloadStream> = new Map<string, DownloadStream>();

/**
 * Initialize
 */
export async function initAsync() {
    await AbstractDomElement.initAsync();
}

/**
 * Get the C# exports of the Blazor gateway WebAssembly (will throw if not initialized!)
 * 
 * @returns Exports
 */
export function getExports(): any {
    return AbstractDomElement.cSharpExports;
}

/**
 * Get an element by its ID
 * 
 * @param id ID
 * @returns DOM element JSON
 */
export function getElementById(id: string): string {
    const element: Element = ensureId(document.getElementById(id));
    return element ? JSON.stringify(new AbstractDomElement(element).toJson()) : null;
}

/**
 * Get elements by a HTML tag name
 * 
 * @param tag HTML tag name
 * @returns DOM elements JSON
 */
export function getElementsByTagName(tag: string): string {
    const elements: Array<Element> = ensureIds(Array.from(document.getElementsByTagName(tag))),
        res: Array<string> = [],
        len: number = elements.length;
    for (let i: number = 0; i < len; res.push(new AbstractDomElement(elements[i]).toJson()), i++);
    return JSON.stringify(res);
}

/**
 * Get an element by a CSS selector
 * 
 * @param selector CSS selector
 * @returns DOM element JSON
 */
export function querySelector(selector: string): string {
    const element: Element = ensureId(document.querySelector(selector));
    return element ? JSON.stringify(new AbstractDomElement(element).toJson()) : null;
}

/**
 * Get elements by a CSS selector
 * 
 * @param selector CSS selector
 * @returns DOM elements JSON
 */
export function querySelectorAll(selector: string): string {
    const elements: Array<Element> = ensureIds(Array.from(document.querySelectorAll(selector))),
        res: Array<string> = [],
        len: number = elements.length;
    for (let i: number = 0; i < len; res.push(new AbstractDomElement(elements[i]).toJson()), i++);
    return JSON.stringify(res);
}

/**
 * Get the element count of a CSS selector
 * 
 * @param selector CSS selector
 * @returns Element count
 */
export function querySelectorAllCount(selector: string): number {
    return document.querySelectorAll(selector).length;
}

/**
 * Create an element
 * 
 * @param parent Parent element ID
 * @param tag HTML tag name
 * @param id ID
 * @param attr Attribute map JSON string
 * @param text Inner text
 * @param html Inner HTML
 * @returns ID or NULL on error
 */
export function createElement(parent: string, tag: string, id: string = null, attr: string = null, text: string = null, html: string = null): string {
    if (id != null && document.getElementById(id)) {
        console.warn('DOM element ID "' + id + '" exists already');
        return null;
    }
    const parentElement: Element = document.getElementById(parent);
    if (!parentElement) {
        console.warn('Parent element "' + parent + '" not found');
        return null;
    }
    let attrMap: any = null;
    if (attr != null) {
        attrMap = JSON.parse(attr);
        if (!attrMap) {
            console.warn('Failed to parse the attribute map', attr);
            return null;
        }
    }
    const element = document.createElement(tag);
    element.id = id == null ? generateId() : id;
    if (attrMap) {
        const keys: Array<string> = Array.from(Object.keys(attrMap)),
            keyLen: number = keys.length;
        for (let i = 0; i < keyLen; i++) {
            if (!attrMap.prototype.hasOwnProperty(keys[i])) continue;
            element.setAttribute(keys[i], attrMap[keys[i]]);
        }
    }
    if (text != null) element.innerText = text;
    if (html != null) element.innerHTML = html;
    parentElement.appendChild(element);
    return element.id;
}

/**
 * Remove an element
 * 
 * @param id ID
 * @returns If the element was removed
 */
export function removeElement(id: string): boolean {
    if (Elements.has(id)) {
        const e: AbstractDomElement = Elements.get(id);
        e.clearEventListeners();
        Elements.delete(id);
    }
    const element: Element = document.getElementById(id);
    if (!element) return false;
    element.remove();
    return true;
}

/**
 * Add an event listener
 * 
 * @param id ID
 * @param event Event
 * @returns If the event listener was added
 */
export function addEventListener(id: string, event: string): boolean {
    const existing: AbstractDomElement = Elements.get(id);
    if (existing) return existing.addEventListener(event);
    const element: Element = document.getElementById(id),
        e: AbstractDomElement = element ? new AbstractDomElement(element) : null;
    if (!e) return false;
    Elements.set(id, e);
    return e.addEventListener(event);
}

/**
 * Remove the event listener
 * 
 * @param id ID
 * @param event Event
 * @returns If the event listener was removed
 */
export function removeEventListener(id: string, event: string): boolean {
    const existing: AbstractDomElement = Elements.get(id),
        res: boolean = existing && existing.removeEventListener(event);
    if (!res) return res;
    if (!existing.hasEventListeners) Elements.delete(id);
    return res;
}

/**
 * Clear all event listeners
 * 
 * @param id ID
 * @returns If the event listeners were removed
 */
export function clearEventListeners(id: string): boolean {
    const existing: AbstractDomElement = Elements.get(id);
    if (!existing) return false;
    existing.clearEventListeners();
    Elements.delete(id);
    return true;
}

/**
 * Set an element attribute
 * 
 * @param id ID
 * @param name Name
 * @param value Value
 * @returns If the attribute was set
 */
export function setAttribute(id: string, name: string, value: string): boolean {
    const element: Element = document.getElementById(id);
    if (!element) return false;
    element.setAttribute(name, value);
    return true;
}

/**
 * Set many element attributes
 * 
 * @param id ID
 * @param settings JSON encoded DOM element settings
 * @returns If the attributes were set
 */
export function setAttributes(id: string, settings: string): boolean {
    const element: Element = document.getElementById(id);
    if (!element) return false;
    DomElementSettings.FromJson(settings).ApplyTo(element);
    return true;
}

/**
 * Remove an element attribute
 * 
 * @param id ID
 * @param name Name
 * @returns If the attribute was set
 */
export function removeAttribute(id: string, name: string): boolean {
    const element: Element = document.getElementById(id);
    if (!element) return false;
    element.removeAttribute(name);
    return true;
}

/**
 * Insert an element to a target element
 * 
 * @param id ID
 * @param target Target ID
 * @param index Target index
 * @returns boolean If inserted
 */
export function insertBefore(id: string, target: string, index: number): boolean {
    const element: Element = document.getElementById(id),
        targetElement: Element = element ? document.getElementById(target) : null;
    if (!targetElement) return false;
    if (index < 1) {
        const firstChild: ChildNode = targetElement.firstChild;
        if (firstChild) {
            targetElement.insertBefore(element, firstChild);
        }else{
            targetElement.appendChild(element);
        }
    } else {
        const child: ChildNode = targetElement.childNodes.item(index)
        if (!child) return false;
        targetElement.insertBefore(element, child);
    }
    return true;
}

/**
 * Append an element to a target element
 * 
 * @param id ID
 * @param target Target ID
 * @returns boolean If appended
 */
export function appendChild(id: string, target: string): boolean {
    const element: Element = document.getElementById(id),
        targetElement: Element = element ? document.getElementById(target) : null;
    if (!targetElement) return false;
    targetElement.appendChild(element);
    return true;
}

/**
 * Determine if an element exists in the DOM
 * 
 * @param id ID
 * @returns If exists
 */
export function exists(id: string): boolean {
    return !!document.getElementById(id);
}

/**
 * Run a stream from a DotNetStreamReference
 * 
 * @param source Source stream (DotNetStreamReference)
 * @param fn Filename (if NULL, the download won't be started in the browser)
 * @param mime MIME type (if NULL, the default is "application/octet-stream")
 * @param wait Wait for the streaming to be done?
 * @returns Download stream ID or NULL, if awaited
 */
export async function runStreamAsync(source: any, fn: string = null, mime: string = null, wait: boolean = false): Promise<string> {
    const stream: DownloadStream = new DownloadStream(fn, mime, await source.stream());
    if (!wait) {
        DownloadStreams.set(stream.id, stream);
        return stream.id;
    }
    await stream.streamPromise;
    return null;
}

/**
 * Start a file download stream
 * 
 * @param fn Filename (if NULL, the download won't be started in the browser)
 * @param mime MIME type (if NULL, the default is "application/octet-stream")
 * @returns Download stream ID
 */
export function startDownloadStream(fn: string = null, mime: string = null): string {
    const stream: DownloadStream = new DownloadStream(fn, mime);
    DownloadStreams.set(stream.id, stream);
    return stream.id;
}

/**
 * Add a data chunk to a download stream
 * 
 * @param id ID
 * @param data base64 encoded data chunk
 * @returns If still streaming
 */
export function addDownloadStreamChunk(id: string, data: string): boolean {
    const stream: DownloadStream = DownloadStreams.get(id);
    if (!stream || stream.isFinalized) return false;
    stream.addDataChunk(data);
    return true;
}

/**
 * Add a data chunk to a download stream
 * 
 * @param id ID
 * @param data Data chunk bytes
 * @returns If still streaming
 */
export function addDownloadStreamChunkArray(id: string, data: Uint8Array): boolean {
    const stream: DownloadStream = DownloadStreams.get(id);
    if (!stream || stream.isFinalized) return false;
    stream.addDataChunkArray(data);
    return true;
}

/**
 * End a download stream
 * 
 * @param id ID
 * @returns If finalized
 */
export function endDownloadStream(id: string): boolean {
    const stream: DownloadStream = DownloadStreams.get(id);
    if (!stream) return false;
    DownloadStreams.delete(id);
    return stream.finalize();
}

/**
 * Ensure an element has an ID
 * 
 * @param element Element
 * @returns Element
 */
function ensureId(element: Element): Element {
    if (element && element.id == '') element.id = generateId();
    return element;
}

/**
 * Ensure all elements have an ID
 * 
 * @param elements Elements
 * @returns Elements
 */
function ensureIds(elements: Array<Element>): Array<Element> {
    const len: number = elements.length;
    for (let i: number = 0; i < len; ensureId(elements[i]), i++);
    return elements;
}

/**
 * Generate a unique ID for an element
 * 
 * @returns ID
 */
function generateId(): string {
    let res: Array<string> = null;
    while (!res || document.getElementById(res.join(''))) {
        res = [];
        for (let i: number = 0; i < 10; res.push(Alphabet[Math.floor(Math.random() * Alphabet.length)]), i++);
        res.push(Date.now().toString());
    }
    return res.join('');
}
