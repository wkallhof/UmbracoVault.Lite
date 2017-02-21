#Vault Lite

A lightweight, stripped down version of the orignal [Umbraco Vault](https://github.com/thenerdery/UmbracoVault) project with a few minor usability modifications. Removes assumptions around certain naming conventions and view engines.

### Notable Changes
1. Removing the `AutoMap = true`. It now always assumes AutoMap


### Supported Default Type Handlers

#### Arrays

```csharp
// Raw integer arrays are supported using a textstring
public int[] IntArray { get; set; }

// Raw string arrays are supported using a textstring
public string[] StringArray { get; set; }

// Generic content lists are supported.
public IList<StaffMember> StaffList { get; set; }

// This contains the list of Checkbox Values
public string[] CheckboxList { get; set; }

// This contains the list of Dictionary Picker values
public string[] DictionaryPicker { get; set; }

// List of Integers that correspond to prevalues in the Umbraco DB. Lookup is required to get text values.
public int[] DropDownListMultiplePublishKeys { get; set; }

// List of dropdown values. Publishes the string entry so no lookup is required
public string[] DropDownListMultiple { get; set; }
```

#### Enums
```csharp

 public enum Month
{
    January = 1,
    ...
}

[UmbracoEnumProperty]
public Month Month { get; set; }
```

#### Numeric Primitives

```csharp
/// Booleans can be represented by the Umbraco true/false type.
public bool Bool { get; set; }

/// Bytes : Supported range: 0 to 255
public byte Byte { get; set; }

/// Decimals : Supported range: -79228162514264337593543950335 to 79228162514264337593543950335
/// <remarks>Exceeds Umbraco numeric type</remarks>
public decimal Decimal { get; set; }

/// Doubles : Supported range: -1.79769313486232e308 to 1.79769313486232e308
/// <remarks>Exceeds Umbraco numeric type</remarks>
public double Double { get; set; }

/// Floats : Supported range: -3.402823e38 to 3.402823e38
public float Float { get; set; }

/// Ints : Supported range: -2,147,483,648 to 2,147,483,647
public int Int { get; set; }

/// Longs : Supported range: -9,223,372,036,854,775,808 .. 9,223,372,036,854,775,807
/// <remarks>Exceeds Umbraco numeric type</remarks>
public long Long { get; set; }

/// Signed Bytes : Supported range: -128 to 127
public sbyte SByte { get; set; }

/// Shorts : Supported range: -32,768 to 32,767
public short Short { get; set; }

/// Unsigned Ints : Supported range: 0 to 4,294,967,295
/// <remarks>Exceeds Umbraco numeric type</remarks>
public uint UInt { get; set; }

/// Unsigned Longs : Supported range: 0 to 18,446,744,073,709,551,615
/// <remarks>Exceeds Umbraco numeric type</remarks>
public ulong ULong { get; set; }

/// Unsigned Shorts : Supported range: 0 to 65,535
public ushort UShort { get; set; }

/// Slider property editor : Supported range: 0 to 2,147,483,647
/// <remarks>Slider doesn't support negative values</remarks>
public int Slider { get; set; }
```

#### Text Primitives
```csharp
/// A char can hold a single character.
public char Char { get; set; }

/// A string can hold many characters.
public string String { get; set; }

/// Rich text is a string with macros applied.
[UmbracoRichTextProperty]
public string RichText { get; set; }

/// Uses the RichText property above but converts directly into an HtmlString which
/// avoids the need for an Html.Raw() call in the view.
public HtmlString RichTextAsHtmlString { get; set; }

/// Uses a plain text value to populate this, similar to the example above
public HtmlString HtmlString { get; set; }

/// Gets the value from a drop down list (the actual text from it)
public string DropDownList { get; set; }

/// Uses a drop down list but for this type Umbraco publishes an ID key which
/// requires a lookup from umbraco.library.GetPreValueAsString(id) to retrieve
/// the string value
public int DropDownListPublishKeys { get; set; }

/// Radio Button List prevalue ID
public int RadioButtonList { get; set; }

/// Radio Button List prevalue
public string RadioButtonListAsString { get; set; }
```

#### Objects
```csharp
///Representation of an image by URL and alt tag
[UmbracoMediaEntity]
public class Image
{
    [UmbracoProperty(Alias = "umbracoFile")]
    public string Url { get; set; }

    public string Alt { get; set; }
}

/// <summary>
/// Representation of a location
/// </summary>
[UmbracoEntity]
public class Location
{
    public string Name { get; set; }
}

/// <summary>
/// Model of a person
/// </summary>
/// <remarks>
/// Shows how objects referencing other objects are handled by Vault.
/// </remarks>
[UmbracoEntity(Alias = "person")]
public class StaffMember
{
    public string Name { get; set; }
    public Location PrimaryLocation { get; set; }
}

[UmbracoEntity]
public class ObjectsViewModel : CmsViewModelBase
{
    public DateTime DateFromPicker { get; set; }
    public DateTime DateFromText { get; set; }
    public IEnumerable<StaffMember> MultiNodeTreePicker { get; set; }
}
```
