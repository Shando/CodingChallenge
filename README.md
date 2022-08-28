# CodingChallenge

#Five High Risk Areas:

1)	Login:
	If this functionality fails or does not work properly, then customers will not be able to view their account
2)	Search:
	If this functionality fails or does not work properly, then customers will not be able to locate products
3)	Add to Cart:
	If this functionality fails or does not work properly, then customers will not be able to purchase products
4)	Register:
	If this functionality fails or does not work properly, then customers will not be able to create an account
5)	Checkout:
	If this functionality fails or does not work properly, then customers will not be able to purchase products

#Automated Tests:

1)	Login Functionality (both with a valid and invalid email/password)
2)	Search Functionality
3)	Add to Cart Functionality

I have chosen the above as I also had to learn NUnit / Selenium / XPath at the same time and these 3 functionaliies appeared to be the easiest to test.

#How to Build & Run:

All Tests can be run from Test Explorer in Visual Studio. NB: Test Explorer will automatically run the build of the tests.

#Improvements:

With more time, I could expand the tests to include such things as running a loop for the 'Search' and 'Add to Cart' tests to check different search terms and different products.

#Software Used

Visual Studio 2022							Version 17.3.0 Preview 6.0
.Net										6.0
coverlet.collector							v3.1.2
DotetSeleniumExtras.PageObjects				v3.1.1.0
DotetSeleniumExtras.PageObjects.Core		v4.3.0
DotetSeleniumExtras.PageObjects.Core.Linq	v1.0.0
DotetSeleniumExtras.WaitHelpers				v3.1.1.0
Microsoft.NET.Test.Sdk						v17.3.0
NUnit										v3.13.3
NUnit.Analyzers								v3.3.0
NUnit3TestAdapter							v4.2.1
Selenium.WebDriver							v4.4.0
