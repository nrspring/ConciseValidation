ConciseValidation
=================

An easily readable dot net based object validation library ...

Features include
- Common validation routines (not null, max lenght, min length, is date, max date, min date, phone, email, regex, predicate functions)
- Validation definitions are similar to definitions in other popular projects such as AutoMap and Castle Windsor
- Validations can be chained in a single line
- Validations are defined in extension methods making it easy to add new validation routines
- Full intellisense
- Full unit-test coverage

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


//The resulting errors are stored in the collection on the validator object
foreach(var currentItem in validator.ValidationErrors){
	Console.WriteLine(string.Format(@"{0} -> {1}", currentItem.Field, currentItem.Message));
}

```