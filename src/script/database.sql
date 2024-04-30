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


