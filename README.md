ConciseValidation
=================

An easily readable dot net based object validation library ...

Features include
- Common validation routines (not null, max length, min length, is date, max date, min date, phone, email, regex, predicate functions)
- Validation definitions are similar to definitions in other popular projects such as AutoMap and Castle Windsor
- Validations can be chained in a single line
- Validations are defined in extension methods making it easy to add new validation routines
- Full intellisense
- Full unit-test coverage

Features added December 2014
- Added validation to determine if a string can be converted to a decimal

Features added October 2013
- Property data types for DateTime, Int and Double (previously only available for strings)
- Added validation for Ints (Max and Min), Double (MaxValue and MinValue) and DateTime (MaxDate and MinDate)

Sample code (see the unit tests for even more scenarios)
```csharp
Person JoeSmith = new Person(){
	FirstName = "Joe",
	LastName = "Smith",
	BirthDate = "11/11/2001",
	PhoneNumber = "(614) 555-1212",
	EmailAddress = "a@b.com"
};

var validator = new ConciseValidation.Validator<Person>(JoeSmith);


//Validate that first name is not null and has at least 2 characters.  This uses a default error message
validator.ValidateField(item => item.FirstName).NotNull().MinLength(2);

//Validate that the birthdate is not null, is a valid date and is no later than 1/1/1990.  The last constraint has a custom error message
validator.ValidateField(item => item.BirthDate).NotNull().IsDate().MaxDate(DateTime.Parse("1/1/1990"),"Whoa!  You are too young to use this!");

//Validate, using regex, that the last name is 5 characters long and the 3rd character is a lower-case 'i'
validator.ValidateField(item => item.LastName).MatchRegex("..i..","The last name doesnt meet the requirements");

//Validate that the phone number is not null and is valid
validator.ValidateField(item => item.PhoneNumber).NotNull().MatchPhone();

//Validate that the email address is not null and is valid
validator.ValidateField(item => item.EmailAddress).NotNull().MatchEmail();

//Validate the first name with an inline predicate function
validator.ValidateField(item => item.FirstName).ValidateByFunction(x => x.FieldValue != "Joe", "The Name Cannot Be Joe.");

//Validate the first name with an existing predicate function
private bool CheckFirstName(string value)
{
	return value != "Joe";
}

validator.ValidateField(item => item.FirstName).ValidateByFunction(x => CheckFirstName(x.FieldValue), "The Name Cannot Be Joe.");

//The resulting errors are stored in the collection on the validator object
foreach(var currentItem in validator.ValidationErrors){
	Console.WriteLine(string.Format(@"{0} -> {1}", currentItem.Field, currentItem.Message));
}

```

Sample code for features added December 2014
```csharp
Stuff Item = new Stuff(){
	DecimalAsString = "3.14"
};

var validator = new ConciseValidation.Validator<Stuff>(Item);

//See if a string can be converted to a decimal
validator.ValidateField(item => item.DecimalAsString).IsNumber();


```
Sample code for features added October 2013
```csharp
Stuff Item = new Stuff(){
	IntValue = 17,
	DoubleValue = 18.2,
	DateValue = new System.DateTime(2001,11,11),
	DateAsString = "11/11/2001"
};

var validator = new ConciseValidation.Validator<Stuff>(Item);

//See if the integer falls within the right bounds
validator.ValidateField(item => item.IntValue).MinValue(15).MaxValue(25);

//See if the double falls within the right bounds
validator.ValidateField(item => item.DoubleValue).MinValue(15.7).MaxValue(25.3);

//See if the date falls within the right bounds
validator.ValidateField(item => item.DateValue).MinDate(new System.DateTime(2001,1,1)).MaxDate(new System.DateTime(2001,12,31));

//See if a string is null, is convertable to a date and falls within a specific date range
validator.ValidateField(item => item.DateAsString).NotNull().IsDateConvertToDate().MinDate(new System.DateTime(2001,1,1)).MaxDate(new System.DateTime(2001,12,31));

```