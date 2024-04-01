using Microsoft.AspNetCore.Components;

namespace wan24.Blazor
{
    /// <summary>
    /// Interface for a flex layout
    /// </summary>
    public interface IFlexLayout : ILayout
    {
        /// <summary>
        /// Stretch the content sidebar over header and footer?
        /// </summary>
        bool StretchContentSidebar { get; }
        /// <summary>
        /// Body HTML tag name
        /// </summary>
        string BodyTag { get; }
        /// <summary>
        /// Body parameters
        /// </summary>
        Dictionary<string, object>? BodyParameters { get; }
        /// <summary>
        /// Content flex box type (defines the sidebar and body apperance in landscape/portrait view on a small/large screen)
        /// </summary>
        FlexBoxTypes ContentFlex { get; }
        /// <summary>
        /// Content flex box type in landscape view
        /// </summary>
        FlexBoxTypes LandscapeContentFlex { get; }
        /// <summary>
        /// Content flex box type in portrait view
        /// </summary>
        FlexBoxTypes PortraitContentFlex { get; }
        /// <summary>
        /// Content flex box type in landscape view on a small screen
        /// </summary>
        FlexBoxTypes SmallLandscapeContentFlex { get; }
        /// <summary>
        /// Content flex box type in portrait view on a small screen
        /// </summary>
        FlexBoxTypes SmallPortraitContentFlex { get; }
        /// <summary>
        /// Body flex box type (used to change the container flex box behavior for <see cref="StretchContentSidebar"/> use)
        /// </summary>
        FlexBoxTypes BodyFlex { get; }
        /// <summary>
        /// Content body flex box type (defines the body and content sidebar apperance in landscape/portrait view on a small/large screen)
        /// </summary>
        FlexBoxTypes ContentBodyFlex { get; }
        /// <summary>
        /// Content body flex box type in landscape view
        /// </summary>
        FlexBoxTypes LandscapeContentBodyFlex { get; }
        /// <summary>
        /// Content body flex box type in portrait view
        /// </summary>
        FlexBoxTypes PortraitContentBodyFlex { get; }
        /// <summary>
        /// Content body flex box type in landscape view on a small screen
        /// </summary>
        FlexBoxTypes SmallLandscapeContentBodyFlex { get; }
        /// <summary>
        /// Content body flex box type in portrait view on a small screen
        /// </summary>
        FlexBoxTypes SmallPortraitContentBodyFlex { get; }
        /// <summary>
        /// Top header component type (must be a <see cref="ComponentBase"/> with a parameterless constructor)
        /// </summary>
        Type? TopHeader { get; }
        /// <summary>
        /// Top header parameters
        /// </summary>
        Dictionary<string, object>? TopHeaderParameters { get; }
        /// <summary>
        /// Display the top header?
        /// </summary>
        bool DisplayTopHeader { get; }
        /// <summary>
        /// Top header HTML tag name
        /// </summary>
        string TopHeaderTag { get; }
        /// <summary>
        /// Show the top header on a landscape screen?
        /// </summary>
        bool ShowTopHeaderOnLandscape { get; }
        /// <summary>
        /// Show the top header on a small landscape screen?
        /// </summary>
        bool ShowTopHeaderOnSmallLandscape { get; }
        /// <summary>
        /// Show the top header on a portrait screen?
        /// </summary>
        bool ShowTopHeaderOnPortrait { get; }
        /// <summary>
        /// Show the top header on a small portrait screen?
        /// </summary>
        bool ShowTopHeaderOnSmallPortrait { get; }
        /// <summary>
        /// Sidebar component type (must be a <see cref="ComponentBase"/> with a parameterless constructor)
        /// </summary>
        Type? Sidebar { get; }
        /// <summary>
        /// Sidebar parameters
        /// </summary>
        Dictionary<string, object>? SidebarParameters { get; }
        /// <summary>
        /// Display the sidebar?
        /// </summary>
        bool DisplaySidebar { get; }
        /// <summary>
        /// Sidebar HTML tag name
        /// </summary>
        string SidebarTag { get; }
        /// <summary>
        /// Show the sidebar on a landscape screen?
        /// </summary>
        bool ShowSidebarOnLandscape { get; }
        /// <summary>
        /// Show the sidebar on a small landscape screen?
        /// </summary>
        bool ShowSidebarOnSmallLandscape { get; }
        /// <summary>
        /// Show the sidebar on a portrait screen?
        /// </summary>
        bool ShowSidebarOnPortrait { get; }
        /// <summary>
        /// Show the sidebar on a portrait screen?
        /// </summary>
        bool ShowSidebarOnSmallPortrait { get; }
        /// <summary>
        /// Header component type (must be a <see cref="ComponentBase"/> with a parameterless constructor)
        /// </summary>
        Type? Header { get; }
        /// <summary>
        /// Header parameters
        /// </summary>
        Dictionary<string, object>? HeaderParameters { get; }
        /// <summary>
        /// Display the header?
        /// </summary>
        bool DisplayHeader { get; }
        /// <summary>
        /// Header HTML tag name
        /// </summary>
        string HeaderTag { get; }
        /// <summary>
        /// Show the header on a landscape screen?
        /// </summary>
        bool ShowHeaderOnLandscape { get; }
        /// <summary>
        /// Show the header on a small landscape screen?
        /// </summary>
        bool ShowHeaderOnSmallLandscape { get; }
        /// <summary>
        /// Show the header on a portrait screen?
        /// </summary>
        bool ShowHeaderOnPortrait { get; }
        /// <summary>
        /// Show the header on a portrait screen?
        /// </summary>
        bool ShowHeaderOnSmallPortrait { get; }
        /// <summary>
        /// Body header component type (must be a <see cref="ComponentBase"/> with a parameterless constructor)
        /// </summary>
        Type? BodyHeader { get; }
        /// <summary>
        /// Body header parameters
        /// </summary>
        Dictionary<string, object>? BodyHeaderParameters { get; }
        /// <summary>
        /// Display the body header?
        /// </summary>
        bool DisplayBodyHeader { get; }
        /// <summary>
        /// Body header HTML tag name
        /// </summary>
        string BodyHeaderTag { get; }
        /// <summary>
        /// Show the body header on a landscape screen?
        /// </summary>
        bool ShowBodyHeaderOnLandscape { get; }
        /// <summary>
        /// Show the body header on a small landscape screen?
        /// </summary>
        bool ShowBodyHeaderOnSmallLandscape { get; }
        /// <summary>
        /// Show the body header on a portrait screen?
        /// </summary>
        bool ShowBodyHeaderOnPortrait { get; }
        /// <summary>
        /// Show the body header on a portrait screen?
        /// </summary>
        bool ShowBodyHeaderOnSmallPortrait { get; }
        /// <summary>
        /// Body footer component type (must be a <see cref="ComponentBase"/> with a parameterless constructor)
        /// </summary>
        Type? BodyFooter { get; }
        /// <summary>
        /// Body footer parameters
        /// </summary>
        Dictionary<string, object>? BodyFooterParameters { get; }
        /// <summary>
        /// Display the body footer?
        /// </summary>
        bool DisplayBodyFooter { get; }
        /// <summary>
        /// Body footer HTML tag name
        /// </summary>
        string BodyFooterTag { get; }
        /// <summary>
        /// Show the body footer on a landscape screen?
        /// </summary>
        bool ShowBodyFooterOnLandscape { get; }
        /// <summary>
        /// Show the body footer on a small landscape screen?
        /// </summary>
        bool ShowBodyFooterOnSmallLandscape { get; }
        /// <summary>
        /// Show the body footer on a portrait screen?
        /// </summary>
        bool ShowBodyFooterOnPortrait { get; }
        /// <summary>
        /// Show the body footer on a portrait screen?
        /// </summary>
        bool ShowBodyFooterOnSmallPortrait { get; }
        /// <summary>
        /// Sidebar component type (must be a <see cref="ComponentBase"/> with a parameterless constructor)
        /// </summary>
        Type? ContentSidebar { get; }
        /// <summary>
        /// Content sidebar parameters
        /// </summary>
        Dictionary<string, object>? ContentSidebarParameters { get; }
        /// <summary>
        /// Display the content sidebar
        /// </summary>
        bool DisplayContentSidebar { get; }
        /// <summary>
        /// Content sidebar HTML tag name
        /// </summary>
        string ContentSidebarTag { get; }
        /// <summary>
        /// Show the content sidebar on a landscape screen?
        /// </summary>
        bool ShowContentSidebarOnLandscape { get; }
        /// <summary>
        /// Show the content sidebar on a small landscape screen?
        /// </summary>
        bool ShowContentSidebarOnSmallLandscape { get; }
        /// <summary>
        /// Show the content sidebar on a portrait screen?
        /// </summary>
        bool ShowContentSidebarOnPortrait { get; }
        /// <summary>
        /// Show the content sidebar on a portrait screen?
        /// </summary>
        bool ShowContentSidebarOnSmallPortrait { get; }
        /// <summary>
        /// Footer component type (must be a <see cref="ComponentBase"/> with a parameterless constructor)
        /// </summary>
        Type? Footer { get; }
        /// <summary>
        /// Footer parameters
        /// </summary>
        Dictionary<string, object>? FooterParameters { get; }
        /// <summary>
        /// Display the footer?
        /// </summary>
        bool DisplayFooter { get; }
        /// <summary>
        /// Footer HTML tag name
        /// </summary>
        string FooterTag { get; }
        /// <summary>
        /// Show the footer on a landscape screen?
        /// </summary>
        bool ShowFooterOnLandscape { get; }
        /// <summary>
        /// Show the footer on a small landscape screen?
        /// </summary>
        bool ShowFooterOnSmallLandscape { get; }
        /// <summary>
        /// Show the footer on a portrait screen?
        /// </summary>
        bool ShowFooterOnPortrait { get; }
        /// <summary>
        /// Show the footer on a portrait screen?
        /// </summary>
        bool ShowFooterOnSmallPortrait { get; }
        /// <summary>
        /// Bottom footer component type (must be a <see cref="ComponentBase"/> with a parameterless constructor)
        /// </summary>
        Type? BottomFooter { get; }
        /// <summary>
        /// Bottom footer parameters
        /// </summary>
        Dictionary<string, object>? BottomFooterParameters { get; }
        /// <summary>
        /// Display the bottom footer
        /// </summary>
        bool DisplayBottomFooter { get; }
        /// <summary>
        /// Bottom footer HTML tag name
        /// </summary>
        string BottomFooterTag { get; }
        /// <summary>
        /// Show the bottom footer on a landscape screen?
        /// </summary>
        bool ShowBottomFooterOnLandscape { get; }
        /// <summary>
        /// Show the bottom footer on a small landscape screen?
        /// </summary>
        bool ShowBottomFooterOnSmallLandscape { get; }
        /// <summary>
        /// Show the bottom footer on a portrait screen?
        /// </summary>
        bool ShowBottomFooterOnPortrait { get; }
        /// <summary>
        /// Show the bottom footer on a portrait screen?
        /// </summary>
        bool ShowBottomFooterOnSmallPortrait { get; }
    }
}
