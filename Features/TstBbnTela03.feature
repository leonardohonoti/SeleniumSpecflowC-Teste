Feature: TstBbnTela03

A short summary of the feature

@cadastroDeProdutoPrecoInvalido
Scenario: Cadastro de produto preço invalido
	Given Abro o navegador
	When Entro na terceira tela de cadastro de produto
	And Digito o nome do produto "Agua"
	And digito o preço do produto "-1"
	And digito a data de validade valida "01/01/2023"
	And clico em adicionar
	Then Vejo a mensagem no campo preço "Preço invalido"

@cadastroDeProdutoDataInválida
Scenario: Cadastro de produto com data invalida
	Given Abro o navegador
	When Entro na terceira tela de cadastro de produto
	And Digito o nome do produto "agua"
	And digito o preço do produto "10"
	And digito a data de validade invalida "02/01/2023"
	And clico em adicionar
	Then Vejo a mensagem no campo Validade "Validade Invalida"

@cadastroDeProdutoDadosValidos
Scenario: Cadastro de produto com dados Validos
	Given Abro o navegador
	When Entro na terceira tela de cadastro de produto
	And Digito o nome do produto "agua"
	And digito o preço do produto "10"
	And digito a data de validade valida "01/01/2023"
	And clico em adicionar
	Then Verifico que o produto "agua" foi adicionado