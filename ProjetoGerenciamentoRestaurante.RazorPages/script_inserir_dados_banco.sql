/*
	Inserir Dados Garçom 
*/

INSERT into Garcon(
	GarconId,
	Nome,
	Sobrenome,
	Cpf,
	Telefone
)
SELECT 
	(SELECT COALESCE(MAX(GarconId),0) + 1 FROM Garcon) as GarconId,
	'Rodrigo' as Nome,
	'Ribeiro' as Sobrenome,
	'217419' as Cpf,
	'11992668225' as Telefone
;

INSERT into Garcon(
	GarconId,
	Nome,
	Sobrenome,
	Cpf,
	Telefone
)
SELECT 
	(SELECT COALESCE(MAX(GarconId),0) + 1 FROM Garcon) as GarconId,
	'Larissa' as Nome,
	'Valentina Helena Cardoso' as Sobrenome,
	'74177530352' as Cpf,
	'51987200752' as Telefone
;

INSERT into Garcon(
	GarconId,
	Nome,
	Sobrenome,
	Cpf,
	Telefone
)
SELECT 
	(SELECT COALESCE(MAX(GarconId),0) + 1 FROM Garcon) as GarconId,
	'Maitê' as Nome,
	'Carolina Rosa Lopes' as Sobrenome,
	'96732792849' as Cpf,
	'21986728543' as Telefone
;

INSERT into Garcon(
	GarconId,
	Nome,
	Sobrenome,
	Cpf,
	Telefone
)
SELECT 
	(SELECT COALESCE(MAX(GarconId),0) + 1 FROM Garcon) as GarconId,
	'Tomás' as Nome,
	'Marcelo Baptista' as Sobrenome,
	'21751034046' as Cpf,
	'91996068774' as Telefone
;

/*
	Inserir Dados Categoria 
*/

insert into Categoria(
	CategoriaId,
	Nome,
	Descricao
)
SELECT 
	(SELECT COALESCE(MAX(CategoriaId),0) + 1 FROM Categoria) as CategoriaId,
	'Bebidas Alcoólica' as Nome,
	'+18' as Descricao
;

insert into Categoria(
	CategoriaId,
	Nome,
	Descricao
)
SELECT 
	(SELECT COALESCE(MAX(CategoriaId),0) + 1 FROM Categoria) as CategoriaId,
	'Bebidas' as Nome,
	'Todas as idades' as Descricao
;

insert into Categoria(
	CategoriaId,
	Nome,
	Descricao
)
SELECT 
	(SELECT COALESCE(MAX(CategoriaId),0) + 1 FROM Categoria) as CategoriaId,
	'Frutos do Mar' as Nome,
	'Verificar Alergias' as Descricao
;

insert into Categoria(
	CategoriaId,
	Nome,
	Descricao
)
SELECT 
	(SELECT COALESCE(MAX(CategoriaId),0) + 1 FROM Categoria) as CategoriaId,
	'Pizza' as Nome,
	'8 Pedaços' as Descricao
;

/*
	Inserir Dados Produto 
*/

insert into Produto(
	ProdutoId,
	Nome,
	Descricao,
	Preco,
	CategoriaId
)
SELECT 
	(SELECT COALESCE(MAX(ProdutoId),0) + 1 FROM Produto) as ProdutoId,
	'Pizza de Calabresa' as Nome,
	'Uma pizza de calabresa é um prato típico da culinária italiana, composta por uma base de massa de pizza coberta com molho de tomate, queijo muçarela e fatias de calabresa, que é uma linguiça defumada picante. Alguns ingredientes opcionais, como cebola, azeitonas e pimentão, podem ser adicionados para dar um sabor extra à pizza. A pizza de calabresa é uma opção popular em pizzarias em todo o mundo, sendo um prato muito apreciado por quem gosta de alimentos saborosos e picantes.' as Descricao,
	3.66 as Preco,
	4 as CategoriaId
;

insert into Produto(
	ProdutoId,
	Nome,
	Descricao,
	Preco,
	CategoriaId
)
SELECT 
	(SELECT COALESCE(MAX(ProdutoId),0) + 1 FROM Produto) as ProdutoId,
	'Pizza de Calabresa' as Nome,
	'Uma pizza de calabresa é um prato típico da culinária italiana, composta por uma base de massa de pizza coberta com molho de tomate, queijo muçarela e fatias de calabresa, que é uma linguiça defumada picante. Alguns ingredientes opcionais, como cebola, azeitonas e pimentão, podem ser adicionados para dar um sabor extra à pizza. A pizza de calabresa é uma opção popular em pizzarias em todo o mundo, sendo um prato muito apreciado por quem gosta de alimentos saborosos e picantes.' as Descricao,
	36.96 as Preco,
	4 as CategoriaId
;

insert into Produto(
	ProdutoId,
	Nome,
	Descricao,
	Preco,
	CategoriaId
)
SELECT 
	(SELECT COALESCE(MAX(ProdutoId),0) + 1 FROM Produto) as ProdutoId,
	'Pizza 4 Queijos ' as Nome,
	'Uma pizza 4 queijos é um prato típico da culinária italiana, composta por uma base de massa de pizza coberta com molho de tomate e uma mistura de quatro tipos diferentes de queijos, que geralmente são: muçarela, parmesão, gorgonzola e provolone.' as Descricao,
	38.50 as Preco,
	4 as CategoriaId
;

insert into Produto(
	ProdutoId,
	Nome,
	Descricao,
	Preco,
	CategoriaId
)
SELECT 
	(SELECT COALESCE(MAX(ProdutoId),0) + 1 FROM Produto) as ProdutoId,
	'Caipirinha ' as Nome,
	'Limão' as Descricao,
	25.50 as Preco,
	1 as CategoriaId
;

insert into Produto(
	ProdutoId,
	Nome,
	Descricao,
	Preco,
	CategoriaId
)
SELECT 
	(SELECT COALESCE(MAX(ProdutoId),0) + 1 FROM Produto) as ProdutoId,
	'Vodka com Energetico ' as Nome,
	'Askov com RedBull' as Descricao,
	20.00 as Preco,
	1 as CategoriaId
;

insert into Produto(
	ProdutoId,
	Nome,
	Descricao,
	Preco,
	CategoriaId
)
SELECT 
	(SELECT COALESCE(MAX(ProdutoId),0) + 1 FROM Produto) as ProdutoId,
	'Sushi' as Nome,
	'Contém 4 peças' as Descricao,
	50.00 as Preco,
	3 as CategoriaId
;

insert into Produto(
	ProdutoId,
	Nome,
	Descricao,
	Preco,
	CategoriaId
)
SELECT 
	(SELECT COALESCE(MAX(ProdutoId),0) + 1 FROM Produto) as ProdutoId,
	'Sashimi' as Nome,
	'Contém 6 peças' as Descricao,
	55.00 as Preco,
	3 as CategoriaId
;

insert into Produto(
	ProdutoId,
	Nome,
	Descricao,
	Preco,
	CategoriaId
)
SELECT 
	(SELECT COALESCE(MAX(ProdutoId),0) + 1 FROM Produto) as ProdutoId,
	'Coca-Cola' as Nome,
	'600 ml' as Descricao,
	7.99 as Preco,
	2 as CategoriaId
;

insert into Produto(
	ProdutoId,
	Nome,
	Descricao,
	Preco,
	CategoriaId
)
SELECT 
	(SELECT COALESCE(MAX(ProdutoId),0) + 1 FROM Produto) as ProdutoId,
	'Sprite' as Nome,
	'450 ml' as Descricao,
	5.00 as Preco,
	2 as CategoriaId
;

/*
	Inserir Dados Mesa 
*/

insert into Mesa(
	MesaId,
	Numero,
	Status,
	HoraAbertura
)
SELECT 
	(SELECT COALESCE(MAX(MesaId),0) + 1 FROM Mesa)as MesaId,
	205 as Numero,
	true as Status,
	time('22:00') as HoraAbertura
;

insert into Mesa(
	MesaId,
	Numero,
	Status,
	HoraAbertura
)
SELECT 
	(SELECT COALESCE(MAX(MesaId),0) + 1 FROM Mesa)as MesaId,
	210 as Numero,
	true as Status,
	time('20:00') as HoraAbertura
;

insert into Mesa(
	MesaId,
	Numero,
	Status,
	HoraAbertura
)
SELECT 
	(SELECT COALESCE(MAX(MesaId),0) + 1 FROM Mesa)as MesaId,
	240 as Numero,
	false as Status,
	null as HoraAbertura
;

insert into Mesa(
	MesaId,
	Numero,
	Status,
	HoraAbertura
)
SELECT 
	(SELECT COALESCE(MAX(MesaId),0) + 1 FROM Mesa)as MesaId,
	280 as Numero,
	true as Status,
	time('20:30') as HoraAbertura
;

insert into Mesa(
	MesaId,
	Numero,
	Status,
	HoraAbertura
)
SELECT 
	(SELECT COALESCE(MAX(MesaId),0) + 1 FROM Mesa)as MesaId,
	360 as Numero,
	false as Status,
	null as HoraAbertura
;

insert into Mesa(
	MesaId,
	Numero,
	Status,
	HoraAbertura
)
SELECT 
	(SELECT COALESCE(MAX(MesaId),0) + 1 FROM Mesa)as MesaId,
	420 as Numero,
	false as Status,
	null as HoraAbertura
;

/*
	Inserir Dados Atendimento 
*/

insert into Atendimento(
	AtendimentoId,
	MesaId
)
SELECT 
	(SELECT COALESCE(MAX(AtendimentoId),0) + 1 FROM Atendimento)as AtendimentoId,
	1 as MesaId
;

insert into Atendimento(
	AtendimentoId,
	MesaId
)
SELECT 
	(SELECT COALESCE(MAX(AtendimentoId),0) + 1 FROM Atendimento)as AtendimentoId,
	2 as MesaId
;

insert into Atendimento(
	AtendimentoId,
	MesaId
)
SELECT 
	(SELECT COALESCE(MAX(AtendimentoId),0) + 1 FROM Atendimento)as AtendimentoId,
	4 as MesaId
;

/*
	Inserir Dados Atendimento 
*/

insert into Pedido(
	PedidoId,
	AtendimentoId,
	GarconId,
	HorarioPedido
)
SELECT 
	(SELECT COALESCE(MAX(PedidoId),0) + 1 FROM Pedido)as PedidoId,
	1 as AtendimentoId,
	3 as GarconId,
	time('20:34:57') as HorarioPedido
;

insert into Pedido_Produto(
	PedidoProdutoId,
	PedidoId,
	ProdutoId
)
SELECT 
	(SELECT COALESCE(MAX(PedidoProdutoId),0) + 1 FROM Pedido_Produto)as PedidoProdutoId,
	1 as PedidoId,
	4 AS ProdutoId,
	3 as Quantidade
;

