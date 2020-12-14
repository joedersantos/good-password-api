![.NET Core](https://github.com/joedersantos/PrototipoAutFidelidade/workflows/.NET%20Core/badge.svg)

# Good Password API
Protótipo de uma Api que tem por objetivo validar algumas regras para uma boa senha. 
Definições que assumimos para uma boa senha:
- Nove ou mais caracteres
- Ao menos 1 dígito
- Ao menos 1 letra minúscula
- Ao menos 1 letra maiúscula
- Ao menos 1 caractere especial
  - Considere como especial os seguintes caracteres: !@#$%^&*()-+
- Não possuir caracteres repetidos dentro do conjunto

## Solução
Entendendo que as regras para se criar uma senha é uma validação aplicada ao modelo dos dados, fora adicionado um middlewere ou uma camada de código na “Request Pipeline” da Api, para que o modelo seja validado antes de chegar no método do controlador.
Nessa camada de validação foi utilizado a biblioteca “FluentValidation” 

## Pré requisito
- Ter Docker rodando:
> **_Nota:_** Basta executar: docker-compose up -d --build

## Executando a Api
Após subir a imagem Docker do projeto, é possível verificar a rota os parâmetros de request da Api através do Swagger chamando essa url: 
http://localhost:32768/swagger/index.html

