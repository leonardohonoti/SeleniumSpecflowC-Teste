Feature: TstBbnTela01

A short summary of the feature

@cadastroDeProdutoCamposVazios
Scenario: Cadastro de produto sem dados nos campos
	Given Abro o navegador
	When Entro na tela de cadastro de produto
	And Digito o nome do produto ""
	And digito o preço do produto ""
	And digito a data de vancimento ""
	And clico em adicionar
	Then Verifico que o produto foi adicionado sem dados como intem "1"

@cadastroDeProdutoDataInválida
Scenario: Cadastro de produto com data invalida
	Given Abro o navegador
	When Entro na tela de cadastro de produto
	And Digito o nome do produto "agua"
	And digito o preço do produto "10"
	And digito a data de vancimento "01/01/2022"
	And clico em adicionar
	Then Verifico que o produto "agua" foi adicionado
