Feature: TstBbnTela03

A short summary of the feature

@cadastroDeProdutoPrecoInvalidoTela03
Scenario: Cadastro de produto preço invalido Tela 03
	Given Entro na terceira tela de cadastro de produto
	When Digito o nome do produto "Agua"
	And digito o preço do produto "-1"
	And digito a data de validade valida "01/01/2023"
	And clico em adicionar
	Then Vejo a mensagem no campo preço "Preço invalido"

@cadastroDeProdutoDataInválidaTela03
Scenario: Cadastro de produto com data invalida Tela 03
	Given Entro na terceira tela de cadastro de produto
	When Digito o nome do produto "agua"
	And digito o preço do produto "10"
	And digito a data de validade invalida "02/01/2023"
	And clico em adicionar
	Then Vejo a mensagem no campo Validade "Validade Invalida"

@cadastroDeProdutoDadosValidosTela03
Scenario: Cadastro de produto com dados Validos Tela 03
	Given Entro na terceira tela de cadastro de produto
	When Digito o nome do produto "agua"
	And digito o preço do produto "10"
	And digito a data de validade valida "01/01/2023"
	And clico em adicionar
	Then Verifico que o produto "agua" foi adicionado