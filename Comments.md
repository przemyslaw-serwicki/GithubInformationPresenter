Here you can find some comments from myself regarding implementation:

1. As this is simple application, I haven't used ny IoC container.
Normally I would use here some solution like Autofac to properly inject all depenedencies via constructor.

Not to make it complex and install Autofac, I just create dependencies inline.
Normally it's a bad practice but this is a sample application showing how to connect to gibhub and save data to DB.

2. Inside Github service I am using HttpClient that is not disposed by me.
Although it does indirectly implement IDisposable, the standard usage is not to dispose it after every request.

3. Database layer was implemented with the usage of simple repository pattern.
In this particular scenario it wasn't really necessary,
but wanted to show you that how simple is to integrate LiteDB with some design pattern.

If we decide to introduce unit testing, then it would be easier to do it becasue of repositories.
We could implement FakeRepositories pattern to achieve unit testability.

4. This is my first time using LiteDB - I wanted to try some simple, no-relational solution.
Documentation turned out to be really helpful.
After implementing this application, I can recommend it if somebody is looking for a simple, no-relational database solution.

5. There was no requirement regarding Github authorization, so I am using public available API and it's capabilities.

6. Whole task was really interesting and I was having fun doing it.