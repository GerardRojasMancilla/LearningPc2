using Platform_API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Platform_API.Shared.Infrastructure.Interfaces.ASP.Configuration;

/// <summary>
///     An MVC controller-model convention that rewrites <c>[controller]</c> route tokens
///     to their kebab-case equivalents (e.g. <c>FavoriteSources</c> → <c>favorite-sources</c>).
/// </summary>
public class KebabCaseRouteNamingConvention : IControllerModelConvention
{
    /// <summary>
    ///     Applies the kebab-case naming transformation to all selectors on the controller and its actions.
    /// </summary>
    /// <param name="controller">The controller model to transform.</param>
    public void Apply(ControllerModel controller)
    {
        // Transforma la ruta base del controlador
        foreach (var selector in controller.Selectors)
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);

        // Transforma las rutas de cada uno de los métodos (Actions) dentro del controlador
        foreach (var selector in controller.Actions.SelectMany(a => a.Selectors))
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
    }

    /// <summary>
    ///     Helper method to replace the [controller] token with its kebab-case version.
    /// </summary>
    private static AttributeRouteModel? ReplaceControllerTemplate(SelectorModel selector, string name)
    {
        return selector.AttributeRouteModel != null
            ? new AttributeRouteModel
            {
                Template = selector.AttributeRouteModel.Template?.Replace("[controller]", name.ToKebabCase())
            }
            : null;
    }
}