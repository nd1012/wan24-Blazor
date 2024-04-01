using Microsoft.AspNetCore.Components.Routing;

namespace wan24.Blazor
{
    // Menu (item) extensions
    public static partial class Extensions
    {
        /// <summary>
        /// Get all menu items recursive
        /// </summary>
        /// <param name="menu">Menu</param>
        /// <returns>Menu items</returns>
        public static IEnumerable<IMenuItem> GetAllMenuItems(this IMenu menu)
        {
            Queue<IMenuParentItem> parents = [];
            foreach(IMenuItem item in menu.Items)
            {
                yield return item;
                if (item is IMenuParentItem parentItem) parents.Enqueue(parentItem);
            }
            while(parents.TryDequeue(out IMenuParentItem? item))
                foreach(IMenuItem subItem in item.Items)
                {
                    yield return subItem;
                    if (subItem is IMenuParentItem parentItem) parents.Enqueue(parentItem);
                }
        }

        /// <summary>
        /// Find a menu item
        /// </summary>
        /// <param name="menu">Menu</param>
        /// <param name="id">ID</param>
        /// <returns>Found menu item</returns>
        public static IMenuItem? FindMenuItem(this IMenu menu, string id)
        {
            Queue<IMenuParentItem> parents = [];
            foreach (IMenuItem item in menu.Items)
                if (item.Id == id)
                {
                    return item;
                }
                else if (item is IMenuParentItem parentItem)
                {
                    parents.Enqueue(parentItem);
                }
            while (parents.TryDequeue(out IMenuParentItem? item))
                foreach (IMenuItem subItem in item.Items)
                    if (subItem.Id == id)
                    {
                        return subItem;
                    }
                    else if (subItem is IMenuParentItem parentItem)
                    {
                        parents.Enqueue(parentItem);
                    }
            return null;
        }

        /// <summary>
        /// Find a menu item
        /// </summary>
        /// <param name="parent">Menu item</param>
        /// <param name="id">ID</param>
        /// <returns>Found menu item</returns>
        public static IMenuItem? FindMenuItem(this IMenuParentItem parent, string id)
        {
            Queue<IMenuParentItem> parents = [];
            foreach (IMenuItem item in parent.Items)
                if (item.Id == id)
                {
                    return item;
                }
                else if (item is IMenuParentItem parentItem)
                {
                    parents.Enqueue(parentItem);
                }
            while (parents.TryDequeue(out IMenuParentItem? item))
                foreach (IMenuItem subItem in item.Items)
                    if (subItem.Id == id)
                    {
                        return subItem;
                    }
                    else if (subItem is IMenuParentItem parentItem)
                    {
                        parents.Enqueue(parentItem);
                    }
            return null;
        }

        /// <summary>
        /// Set all menu items as inactive
        /// </summary>
        /// <param name="menu">Menu</param>
        /// <returns>Previously active items</returns>
        public static IMenuItem[] ResetActiveItem(this IMenu menu)
        {
            List<IMenuItem> res = [];
            Queue<IMenuParentItem> parents = [];
            foreach (IMenuItem item in menu.Items)
            {
                if (item.IsActiveItem)
                {
                    item.IsActiveItem = false;
                    res.Add(item);
                }
                if (item is IMenuParentItem parentItem) parents.Enqueue(parentItem);
            }
            while (parents.TryDequeue(out IMenuParentItem? item))
                foreach (IMenuItem subItem in item.Items)
                {
                    if (subItem.IsActiveItem)
                    {
                        subItem.IsActiveItem = false;
                        res.Add(subItem);
                    }
                    if (subItem is IMenuParentItem parentItem) parents.Enqueue(parentItem);
                }
            return [.. res];
        }

        /// <summary>
        /// Get the active menu item
        /// </summary>
        /// <param name="menu">Menu</param>
        /// <returns>Active menu item</returns>
        public static IMenuItem? GetActiveItem(this IMenu menu)
        {
            Queue<IMenuParentItem> parents = [];
            IMenuItem? res = null;
            foreach (IMenuItem item in menu.Items)
            {
                if (item.IsActiveItem) res = item;
                if (item is IMenuParentItem parentItem) parents.Enqueue(parentItem);
            }
            while (parents.TryDequeue(out IMenuParentItem? item))
                foreach (IMenuItem subItem in item.Items)
                {
                    if (subItem.IsActiveItem) res = subItem;
                    if (subItem is IMenuParentItem parentItem) parents.Enqueue(parentItem);
                }
            return res;
        }

        /// <summary>
        /// Get the active menu item
        /// </summary>
        /// <param name="parent">Menu item</param>
        /// <returns>Active menu item</returns>
        public static IMenuItem? GetActiveItem(this IMenuParentItem parent)
        {
            Queue<IMenuParentItem> parents = [];
            IMenuItem? res = null;
            foreach (IMenuItem item in parent.Items)
            {
                if (item.IsActiveItem) res = item;
                if (item is IMenuParentItem parentItem) parents.Enqueue(parentItem);
            }
            while (parents.TryDequeue(out IMenuParentItem? item))
                foreach (IMenuItem subItem in item.Items)
                {
                    if (subItem.IsActiveItem) res = subItem;
                    if (subItem is IMenuParentItem parentItem) parents.Enqueue(parentItem);
                }
            return res;
        }

        /// <summary>
        /// Get the matching item which <see cref="IMenuItem.Href"/> matches the given absolute URI path
        /// </summary>
        /// <param name="menu">Menu</param>
        /// <param name="href">Absolute URI path</param>
        /// <param name="match">Match logic (default is the <see cref="IMenu.ActiveMatch"/> setting, priority has the <see cref="IMenuItem.ActiveMatch"/> setting)</param>
        /// <returns>Matching menu item</returns>
        public static IMenuItem? GetMatchingItem(this IMenu menu, string href, NavLinkMatch? match = null)
        {
            match ??= menu.ActiveMatch;
            href = BlazorToolsShared.GetAbsoluteUriPathFromHref(menu.Navigation, href);
            Queue<IMenuParentItem> parents = [];
            IMenuItem? res = null;
            foreach (IMenuItem item in menu.Items)
            {
                if (item.Href is not null && BlazorToolsShared.IsHrefMatch(item.Href, href, item.ActiveMatch ?? match.Value)) res = item;
                if (item is IMenuParentItem parentItem) parents.Enqueue(parentItem);
            }
            while (parents.TryDequeue(out IMenuParentItem? item))
                foreach (IMenuItem subItem in item.Items)
                {
                    if (subItem.Href is not null && BlazorToolsShared.IsHrefMatch(subItem.Href, href, subItem.ActiveMatch ?? match.Value)) res = subItem;
                    if (subItem is IMenuParentItem parentItem) parents.Enqueue(parentItem);
                }
            return res;
        }

        /// <summary>
        /// Get the matching item which <see cref="IMenuItem.Href"/> matches the given absolute URI path
        /// </summary>
        /// <param name="parent">Menu item</param>
        /// <param name="href">Absolute URI path</param>
        /// <param name="match">Match logic (default is the <see cref="IMenu.ActiveMatch"/> setting, priority has the <see cref="IMenuItem.ActiveMatch"/> setting)</param>
        /// <returns>Matching menu item</returns>
        public static IMenuItem? GetMatchingItem(this IMenuParentItem parent, string href, NavLinkMatch? match = null)
        {
            match ??= parent.Menu?.ActiveMatch ?? NavLinkMatch.All;
            if (parent.Menu is not null)
                href = BlazorToolsShared.GetAbsoluteUriPathFromHref(parent.Menu.Navigation, href);
            Queue<IMenuParentItem> parents = [];
            IMenuItem? res = null;
            foreach (IMenuItem item in parent.Items)
            {
                if (item.Href is not null && BlazorToolsShared.IsHrefMatch(item.Href, href, item.ActiveMatch ?? match.Value)) res = item;
                if (item is IMenuParentItem parentItem) parents.Enqueue(parentItem);
            }
            while (parents.TryDequeue(out IMenuParentItem? item))
                foreach (IMenuItem subItem in item.Items)
                {
                    if (subItem.Href is not null && BlazorToolsShared.IsHrefMatch(subItem.Href, href, subItem.ActiveMatch ?? match.Value)) res = subItem;
                    if (subItem is IMenuParentItem parentItem) parents.Enqueue(parentItem);
                }
            return res;
        }

        /// <summary>
        /// Find menu items which <see cref="IMenuItem.Href"/> matches the given absolute URI path
        /// </summary>
        /// <param name="menu">Menu</param>
        /// <param name="href">Absolute URI path</param>
        /// <param name="match">Match logic (default is the <see cref="IMenu.ActiveMatch"/> setting, priority has the <see cref="IMenuItem.ActiveMatch"/> setting)</param>
        /// <returns>Matching menu items</returns>
        public static IEnumerable<IMenuItem> FindMatchingItems(this IMenu menu, string href, NavLinkMatch? match = null)
        {
            Queue<IMenuParentItem> parents = [];
            match ??= menu.ActiveMatch;
            href = BlazorToolsShared.GetAbsoluteUriPathFromHref(menu.Navigation, href);
            foreach (IMenuItem item in menu.Items)
            {
                if (item.Href is not null && BlazorToolsShared.IsHrefMatch(item.Href, href, item.ActiveMatch ?? match.Value)) yield return item;
                if (item is IMenuParentItem parentItem) parents.Enqueue(parentItem);
            }
            while (parents.TryDequeue(out IMenuParentItem? item))
                foreach (IMenuItem subItem in item.Items)
                {
                    if (subItem.Href is not null && BlazorToolsShared.IsHrefMatch(subItem.Href, href, subItem.ActiveMatch ?? match.Value)) yield return subItem;
                    if (subItem is IMenuParentItem parentItem) parents.Enqueue(parentItem);
                }
        }

        /// <summary>
        /// Find menu items which <see cref="IMenuItem.Href"/> matches the given absolute URI path
        /// </summary>
        /// <param name="parent">Menu item</param>
        /// <param name="href">Absolute URI path</param>
        /// <param name="match">Match logic (default is the <see cref="IMenu.ActiveMatch"/> setting, priority has the <see cref="IMenuItem.ActiveMatch"/> setting)</param>
        /// <returns>Matching menu items</returns>
        public static IEnumerable<IMenuItem> FindMatchingItems(this IMenuParentItem parent, string href, NavLinkMatch? match = null)
        {
            Queue<IMenuParentItem> parents = [];
            match ??= parent.Menu?.ActiveMatch ?? NavLinkMatch.All;
            if (parent.Menu is not null)
                href = BlazorToolsShared.GetAbsoluteUriPathFromHref(parent.Menu.Navigation, href);
            foreach (IMenuItem item in parent.Items)
            {
                if (item.Href is not null && BlazorToolsShared.IsHrefMatch(item.Href, href, item.ActiveMatch ?? match.Value)) yield return item;
                if (item is IMenuParentItem parentItem) parents.Enqueue(parentItem);
            }
            while (parents.TryDequeue(out IMenuParentItem? item))
                foreach (IMenuItem subItem in item.Items)
                {
                    if (subItem.Href is not null && BlazorToolsShared.IsHrefMatch(subItem.Href, href, subItem.ActiveMatch ?? match.Value)) yield return subItem;
                    if (subItem is IMenuParentItem parentItem) parents.Enqueue(parentItem);
                }
        }

        /// <summary>
        /// Get the menu item path until the root
        /// </summary>
        /// <param name="item">Menu item</param>
        /// <returns>Menu items (including the given menu item) until the root (which is the last item)</returns>
        public static IEnumerable<IMenuItem> GetPath(this IMenuItem item)
        {
            yield return item;
            for (IMenuParentItem? parent = item.Parent; parent is not null; parent = parent.Parent)
                yield return parent;
        }
    }
}
