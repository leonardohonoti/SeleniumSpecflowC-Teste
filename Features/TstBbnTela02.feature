Feature: TstBbnTela02

A short summary of the feature

@cadastroDeProdutoCamposVaziosTela02
Scenario: Cadastro de produto sem dados nos campos Tela02
	Given Entro na segunda tela de cadastro de produto
	When Digito o nome do produto ""
	And digito o preço do produto ""
	And digito a data de validade ""
	And clico em adicionar
	Then Vejo a mensagem no campo nome "Nome invalido"
	And Vejo a mensagem no campo preço "Preço invalido"
	And Vejo a mensagem no campo Validade "Validade Invalida"

@cadastroDeProdutoDataInválidaTela02
Scenario: Cadastro de produto com data invalida e preço invalido Tela 02
	Given Entro na segunda tela de cadastro de produto
	When Digito o nome do produto "agua"
	And digito o preço do produto "-10"
	And digito a data de validade "12/01/2025"
	And clico em adicionar
	Then Verifico que o produto "agua" foi adicionado
