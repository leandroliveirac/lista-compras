insert into categorias(descricao) 
VALUES('ALIMENTOS'),('HIGIENE PESSOAL'),('LIMPEZA'),('UTILIDADES');

SELECT * FROM categorias

SELECT * FROM produtos

INSERT INTO produtos(create_time, descricao,id_categoria)
VALUES(NOW(),'AÇÚCAR',1),(NOW(),'ARROZ',1),(NOW(),'BISCOITOS',1),(NOW(),'CAFÉ',1),
(NOW(),'CARNES',1),(NOW(),'FARINHA LÁCTEA',1),(NOW(),'FARÓFA',1),(NOW(),'FARINHA DE TRIGO',1)
,(NOW(),'FEIJÃO',1),(NOW(),'FERMENTO',1),(NOW(),'HORTALIÇAS',1),(NOW(),'IOGURTE',1),(NOW(),'LEITE',1)
,(NOW(),'MACARRÃO',1),(NOW(),'MARGARINA',1),(NOW(),'MOLHO DE TOMATE',1),(NOW(),'ÓLEO',1),(NOW(),'OVOS',1)
,(NOW(),'PÃES',1),(NOW(),'QUEIJO RALADO',1),(NOW(),'SAL',1),(NOW(),'TEMPEROS',1)
,(NOW(),'ABSORVENTES',2),(NOW(),'ÁGUA OXIGENADA',2),(NOW(),'ALGODÃO',2),(NOW(),'BARBEADOR DESCARTAVEL',2)
,(NOW(),'CREME DE BARBEAR',2),(NOW(),'CREME DENTAL',2),(NOW(),'CURATIVOS',2),(NOW(),'DESODORANTE',2)
,(NOW(),'ESCOVA DE DENTE',2),(NOW(),'ESPARADRAPO',2),(NOW(),'FIO DENTAL',2),(NOW(),'GAZE',2),(NOW(),'HASTE FLEXÍVEL (COTONETE)',2)
,(NOW(),'PAPEL HIGIÊNICO',2),(NOW(),'SABONETE',2),(NOW(),'SHAMPOO',2),(NOW(),'CONDICIONADOR',2)
,(NOW(),'ÁGUA SANITÁRIA',3),(NOW(),'ÁLCOOL EM GEL',3),(NOW(),'AMACIANTE',3),(NOW(),'DESINFETANTE',3),(NOW(),'DETERGENTE',3)
,(NOW(),'ESPONJA DE AÇO',3),(NOW(),'ESPONJA DE AÇO',3),(NOW(),'ESPONJA DE PIA',3),(NOW(),'FLANELAS',3),(NOW(),'INSETICIDA',3)
,(NOW(),'LUSTRA-MÓVEIS',3),(NOW(),'LUVAS PLÁSTICAS',3),(NOW(),'SABÃO EM BARRA',3),(NOW(),'SABÃO EM PÓ',3),(NOW(),'SACOS DE LIXO',3)
,(NOW(),'FÓSFORO',4),(NOW(),'GUARDANAPO DE PAPEL',4),(NOW(),'LÂMPADAS',4),(NOW(),'PAPEL ALUMÍNIO',4),(NOW(),'PAPEL FILME',4)
,(NOW(),'PAPEL TOALHA',4),(NOW(),'VELAS',4)


SELECT 
    C.id_categoria,
    C.descricao,
    P.id_produto,
    P.descricao
FROM categorias C
INNER JOIN produtos P
ON C.id_categoria = P.id_categoria



Insert into `listaCompras`(create_time,descricao)
VALUES(NOW(),'teste1'),(NOW(),'teste2'),(NOW(),'teste3'),(NOW(),'teste4')

SELECT
    * 
FROM listaCompras

SELECT COUNT(*)
      FROM `produtos` AS `p`
      WHERE `p`.`id_produto` IN (1, 3577)