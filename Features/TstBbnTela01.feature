Feature: TstBbnTela01

A short summary of the feature

@cadastroDeProdutoCamposVazios
Scenario: Cadastro de produto sem dados nos campos
	Given Entro na tela de cadastro de produto
	When Digito o nome do produto ""
	And digito o preço do produto ""
	And digito a data de validade ""
	And clico em adicionar
	Then Verifico que o produto foi adicionado sem dados como intem "1"

@cadastroDeProdutoDataInválida
Scenario: Cadastro de produto com data invalida
	Given Entro na tela de cadastro de produto
	When Digito o nome do produto "agua"
	And digito o preço do produto "10"
	And digito a data de validade "01/01/2022"
	And clico em adicionar
	Then Verifico que o produto "agua" foi adicionado
