MvcExtensionsCore
==============

**MvcExtensionsCore** is a port of MvcExtensions (fluent metadata) for Asp.Net Core Mvc.
See for reference https://github.com/MvcExtensions

Status
==============
There is no Nuget package for this library yet. I did this fort for my own needs when I had to port my project from classic ASP.NET MVC to Core. 

What is it?
==============

MvcExtensions is an excellent replacement for DataAnnotations model metadata configurations: fluent model metadata configurations. It is provided unlimited flexibility and extensiblity for your metadata.

First of all you need to enable registration. Use Startup class: 
<br/>
(see Samples for more details)

```csharp
public class Startup
{
    ...

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            // register MvcExtensions metadata and add provider
            .AddMvcExtentions(registry => registry.RegisterConvention(new StringPropertyMetadataConvention()))
            // foolproof validatation extensions for conditional validation
            .AddFoolproof()
            ;
    }
}
```

Second write some metadata configurations for your model:

```csharp
public class ChangePasswordMetadata : MvcExtensionsCore.ModelMetadataConfiguration<ChangePassword>
{
    public ChangePasswordMetadata()
    {
        Configure(x => x.OldPassword)
            .DisplayName("Old password")
            .Required("Old password is required")
            .AsPassword();

        Configure(x => x.NewPassword)
            .DisplayName("New password")
            .Required("New password is required")
            .MinimumLength(6, "Password length should be at least 6 characters")
            .AsPassword();

        Configure(x => x.ConfirmPassword)
            .DisplayName("Password confirmation")
            .Required("Password confirmation is required")
            .Compare("NewPassword", "Password and its confirmation should be equal")
            .AsPassword();
    }
}
```
<br/>

### <a name="#localization-metadata"></a>  Localization with ModelMetadata

MvcExtensions provides a flexible way to perform localization for your models and validation messages.
You can use the resource files in following way:

```csharp
public class ProductEditModelConfiguration : ModelMetadataConfiguration<ProductEditModel>
{
    public ProductEditModelConfiguration()
    {
        Configure(model => model.Id).Hide();

        Configure(model => model.Name).DisplayName(() => LocalizedTexts.Name)
            .Required(() => LocalizedTexts.NameCannotBeBlank)
            .MaximumLength(64, () => LocalizedTexts.NameCannotBeMoreThanSixtyFourCharacters);

        Configure(model => model.Category).DisplayName(() => LocalizedTexts.Category)
            .Required(() => LocalizedTexts.CategoryMustBeSelected)
            .AsDropDownList("categories", () => LocalizedTexts.SelectCategory);

        Configure(model => model.Price).DisplayName(() => LocalizedTexts.Price)
            .FormatAsCurrency()
            .Required(() => LocalizedTexts.PriceCannotBeBlank)
            .Range(10.00m, 1000.00m, () => LocalizedTexts.PriceMustBeBetweenTenToThousand);
    }
}
```

As you can see we are using `Func<string>` to set the localized text, this is just an overload with the regular string method.

Built-in ASP.NET Core localization is also available.

License
--------------------------------
[Microsoft Public License (Ms-PL)](http://www.opensource.org/licenses/MS-PL)
