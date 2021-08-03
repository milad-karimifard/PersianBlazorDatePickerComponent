**1 - First install package** 

```
Install-Package PersianBlazorDatePickerComponent -Version 1.0.0
```

**2 - Reference styles**

In ***wwwroot*** folder open ***Index.html*** file and add this reference inside head tag

```html
    <link href="_content/PersianBlazorDatePickerComponent/css/DatePicker.css" rel="stylesheet" />
```

**3 - Import Component**

Add the code below to **_Imports.razor**  file to import the component`

```razor
@using PersianBlazorDatePickerComponent
```

**4 - Initialize Component**

For initialize the component you must use **PersianDatePicker** tag in your page. this tag require 4 property to set.

- **ref : **  instance of *PersianDatePicker* class
- **SelectedDateTimeValueChanged : ** an event fires when new value selected and return selected value (DateTime)
  - returned value calendar is Gregorian
- **MinDateTime : ** Minimum value can selected by component
  - Must input Gregorian Date
- **MaxDateTime : ** Maximum value can selected by component
  - Must input Gregorian Date

Example :

```C#
<PersianDatePicker @ref="theDatePicker"
                   SelectedDateTimeValueChanged="ClickHandler"
                   MinDateTime=DateTime.Now.AddYears(-10)
                   MaxDateTime=DateTime.Now.AddYears(10)/>
@code
{
    private PersianDatePicker theDatePicker;
    DateTime selectedDateTime;

    void ClickHandler(DateTime date)
    {
        selectedDateTime = date;
    }
}
```

Now component setup successfully completed , just one more step remains. for show component in page and use it you need a button to trigger the component.

Example

```c#
<button @onclick="OpenDatePicker" class="btn btn-dark">Open</button>
<PersianDatePicker @ref="myDatePicker"
                   SelectedDateTimeValueChanged="ClickHandler"
                   MinDateTime=DateTime.Now.AddYears(-10)
                   MaxDateTime=DateTime.Now.AddYears(10)/>
@code
{
    private PersianDatePicker theDatePicker;
    DateTime selectedDateTime;

    void ClickHandler(DateTime date)
    {
        selectedDateTime = date;
    }

    private void OpenDatePicker()
    {
        theDatePicker.ToggleActiveDatePicker();
    }
}
```

