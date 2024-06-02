-- Active: 1714490070979@@app-lista-compr.mysql.uhserver.com@3306@app_lista_compr
CREATE TABLE categorias(  
    id_categoria int NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'Primary Key',
    create_time DATETIME COMMENT 'Create Time',
    descricao VARCHAR(255) NOT NULL
) COMMENT 'Categoria com base organização dos supermercado';


CREATE TABLE produtos(  
    id_produto int NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'Primary Key',
    create_time DATETIME COMMENT 'Create Time',
    descricao VARCHAR(255) NOT NULL,
    id_categoria int NOT NULL
);

ALTER TABLE produtos
ADD CONSTRAINT fk_categoriaProduto FOREIGN KEY (id_categoria) 
    REFERENCES categorias(id_categoria)


CREATE TABLE listaCompras(  
    id_lista_compras int NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'Primary Key',
    create_time DATETIME COMMENT 'Create Time',
    descricao VARCHAR(255) NOT NULL
);

CREATE TABLE itensListaCompras(  
    id_itens_lista_compras int NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'Primary Key',
    create_time DATETIME COMMENT 'Create Time',
    id_lista_compras int NOT NULL,
    id_produto int NOT NULL
);

ALTER TABLE itensListaCompras
ADD CONSTRAINT fk_listaComprasItensListaCompra FOREIGN KEY(id_lista_compras)
    REFERENCES listaCompras(id_lista_compras)

ALTER TABLE itensListaCompras
ADD CONSTRAINT fk_produtoItensListaCompra FOREIGN KEY(id_produto)
    REFERENCES produtos(id_produto)



select 
    ic.id_itens_lista_compras id
    -- ,lc.id_lista_compras
    ,lc.descricao DescricaoLista
    ,p.id_produto IdProduto
    ,p.descricao DescricaoProduto
    ,c.id_categoria IdCategoria
    ,c.descricao DescricaoCategoria
from itensListaCompras ic
inner join listaCompras lc
on ic.id_lista_compras = lc.id_lista_compras
inner join produtos p
on ic.id_produto = p.id_produto
inner join categorias c
on p.id_categoria = c.id_categoria
where ic.id_lista_compras = 1