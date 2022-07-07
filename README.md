This application was developed by following the requirements below.

During the development, the following assumptions were made:
* SQLServer for the database.
* The Divide method in the SimpleCalculator class will throw an exception if the client tries to divide by zero.
* Serilog for the logging framework.

Visual Studio
1. Create an empty solution called CalculatorTest.
2. Create a class library containing the interface below.
3. Create a C# class to realize the interface as a C# class.

public interface ISimpleCalculator\
{\
  int Add(int start, int amount);\
  int Subtract(int start, int amount);\
  int Multiply(int start, int by);\
  float Divide(int start, int by);\
}

TDD\
4. Create a class library containing a suite of unit tests for the interface using test-driven design
principles.

C#\
5. Add a diagnostics interface to the calculator class to allow each method to report its
calculation results to the debugger.\
6. Mock the diagnostics interface and use it to refactor the unit tests so that the test suite
checks that the diagnostics interface is called with expected values.

SQL Server\
7. Create a basic database and update the application to include a new implementation of the
Diagnostics interface which will write the diagnostics information to the database.

Web\
8. Create a simple web service that provides access to a calculator implementation via a REST
API using HTTP.\
9. Create a Web App to invoke the Calculator Web Service (extra points for using Angular)\
10. (Optional) Create a new calculator method called GetPrimeNumber which will accept an
integer to denote which prime number to return (assuming prime numbers are
2,3,5,7,11,13.. passing in 4 would return the 4 th prime number which is 7).\
