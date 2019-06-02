# Single Responsibility Demo - Refactoring for Simplicity and Abstraction

When writing unit tests it quickly becomes apparent if the code you are testing adheres to the Single Responsibility Principle, that is, the code has one responsibility and is not trying to do multiple tasks.

Unit tests should be exactly that; tests for a single unit of functionality - one behaviour. If the code is doing more than one thing, then the tests end up checking more than one thing too, and are no longer "unit" tests.

##One reason to change
Many people assume that SRP means "Do one thing", but actually the definition of the Single Responsibility Principle is: writing code that has one and only one reason to change. If a class has more than one reason to change, it has more than one responsibility. Classes with more than a single responsibility should be broken down into smaller classes, each of which should have only one responsibility and reason to change.

##Refactoring for Simplicity
The first step in refactoring a class for the Single Responsibility Principle is to break it down into smaller methods which focus on single tasks. For example, reading data, logging, outputting results are all distinct responsibilities.

In the example file below, this is done in step 2, Refactor for Simplicity. You will see that we now have a single class broken down into multiple private methods.

This is better than before, but still less than ideal, as the class itself still has multiple reasons to change:

- If we want to read data from something other than a text file
- If we wanted to log somewhere other than the console
- If we wanted to save the data in a different data store
- If the validation rules change
- If the mapping format changes

This is also less than ideal from a testing perspective. If you were to write tests for this you would have to call the ProcessTrades method, which does multiple actions. This means each test would be extremely complex, covering every aspect of the program, so it would be impossible to test any functionality in isolation.

Also, you cannot (or should not) test private methods. But as you will see in the next step, these methods don't have to be private, if you design them into their own classes.

##Delegating to abstractions
The next step is to refactor for abstraction.

Delegating to abstractions is the linchpin of adaptive code and, without it, developers would struggle to adapt to changing requirements in the way that Scrum and other Agile processes demand.

In the process of delegating to abstractions, we decouple the implementation details from our code. We think about what we expect it to do, without concern for how it does it. A refactored class no longer contains the implementation details for the whole process but instead contains the blueprint for the process.

See step 3: Refactor for Abstraction in the code below. Here we have broken down the code into multiple classes which each have a single responsibility; reading data, storing data, mapping data, validation, and logging. On top of that, the calling code does not need to be concerned with how this is done, only what it is doing. That way, if the how changes, any calling code remains unaffected. You might also switch out implementations in different scenarios.

In this case we separate the how from the what by using interfaces. You may notice that our implementation classes are not named the same as the interfaces but with the "I" removed. They are called "SimpleTradeParser" or "StreamTradeDataProvider". This is important because implementations should not be direct copies of the interface, they should have a non-abstract, implementation specific purpose, and the name should reflect this.

Now that our main class is dependent only on abstractions, we can write tests for it by mocking these dependencies. When testing our class (TradeProcessor.cs), we are not concerned about how these dependencies work, we can mock what they return to simulate certain scenarios, and concentrate on the logic in our method (albeit not a lot in this example..).

Then, the implementation classes can also be tested separately to ensure that they function as expected. These can be simple unit tests for classes such as SimpleTradeParser, or integration tests for any implementation of ITradeStorage.
