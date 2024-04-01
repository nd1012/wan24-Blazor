using wan24.Blazor.Parameters;

namespace wan24.Blazor
{
    /// <summary>
    /// Interface for a parent component (which renders child content)
    /// </summary>
    public interface IParentComponent : IBlazorComponent, IParentComponentParameters, IServeChildContent
    {
    }
}
