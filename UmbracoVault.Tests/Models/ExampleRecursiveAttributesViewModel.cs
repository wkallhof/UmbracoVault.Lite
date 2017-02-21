using UmbracoVault.Attributes;

namespace UmbracoVault.Tests.Models
{
    [UmbracoEntity()]
    public class ExampleRecursiveAttributesViewModel : BaseRecursiveAttributesViewModel
    {
    }

    [UmbracoEntity()]
    public class BaseRecursiveAttributesViewModel
    {
    }
}
