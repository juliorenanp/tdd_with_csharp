# tdd_with_csharp
A TDD example using c#

Conceitos:😎

FACT: são testes que são sempre verdade. Eles testam de forma invariante.

THEORY: São testes que são apenas verdadeiros para uma amostra particular de dados.

Ciclo TDD:
1) Novo teste;
2) Teste falha;
3) Corrigir código no negócio ou cenário;
4) Sucesso no código;
5) Refatorar o código.

Todo teste passa por uma preparação, seja de ambiente, variáveis, banco de dados, etc. Essa preparação pode ser chamada em inglês de Arrange. 
Nosso primeiro A.
Em seguida, todo teste passa por um momento onde estimulamos o sistema sendo testado (System Under Test em inglês, ou SUT). Isso é o Act, nosso segundo A.
E logo em seguida, verificarmos se os resultados obtidos batem com os resultados esperados. Isso é o Assert, o terceiro A.


<b>Links úteis</b> 🥓🥓🥓:

Definição de Teste
http://softwaretestingfundamentals.com/definition-of-test/

Padrão AAA (Arrange, Act, Assert)
http://wiki.c2.com/?ArrangeActAssert

Padrão Given/When/Then
https://martinfowler.com/bliki/GivenWhenThen.html

xUnit
https://xunit.github.io/

MSTests
https://github.com/Microsoft/testfx-docs

NUnit
https://nunit.org/

Comparativo entre os frameworks de Teste
https://xunit.github.io/docs/comparisons

Porque xUnit?
https://www.martin-brennan.com/why-xunit/

Microsoft está usando o xUnit
https://dev.to/hatsrumandcode/net-core-2-why-xunit-and-not-nunit-or-mstest--aei

Classes de Equivalência - técnica para identificação de testes relevantes:
https://en.wikipedia.org/wiki/Equivalence_partitioning

Análise de Fronteira - outra técnica:
https://en.wikipedia.org/wiki/Boundary-value_analysis

Definição de Product Owner
https://www.scrum.org/resources/what-is-a-product-owner

Diferença entre [Fact] e [Theory]
https://xunit.github.io/docs/getting-started/netfx/visual-studio#write-first-theory

Nomenclatura de testes
https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices#best-practices

https://docs.microsoft.com/pt-br/dotnet/standard/modern-web-apps-azure-architecture/test-asp-net-core-mvc-apps#test-naming

Testes de métodos privados
https://docs.microsoft.com/pt-br/dotnet/core/testing/unit-testing-best-practices#validate-private-methods-by-unit-testing-public-methods

