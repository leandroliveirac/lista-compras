# ListaCompraWebApp


## Icones
* https://www.flaticon.com/br/icone-gratis/lista-de-compras_7835565



## [Estrutura de pastas para Angular](https://belmirofss.medium.com/minha-nova-estrutura-de-pastas-para-angular-escal%C3%A1vel-limpa-e-f%C3%A1cil-93b6ffb203d9)

```
|-- app
    |-- core
        |-- [+] components
        |-- [+] guards
        |-- [+] interceptors
        |-- [+] models
        |-- [+] layouts
        |-- [+] config
        |-- [+] translations
        |-- [+] overrides
        |-- variables.scss
        |-- theme.scss
        |-- core.module.ts
    |-- features
        |-- login
            |-- components
                |-- [+] login-form
                |-- login-components.module.ts
            |-- interfaces
                |-- login-data.interface.ts
            |-- login.component.ts
            |-- login.component.html
            |-- login.component.scss
            |-- login.component.spec.ts
            |-- login.module.ts
        |-- home
            |-- [+] components
            |-- [+] enums
            |-- [+] interfaces
            |-- home.component.ts
            |-- home.component.html
            |-- home.component.scss
            |-- home.compoment.spec.ts
            |-- home.module.ts
    |-- shared
        |-- [+] components
        |-- [+] validators
        |-- [+] pipes
        |-- [+] directives   
        |-- [+] services
        |-- [+] enums
        |-- shared.module.ts
|-- app.component.ts
|-- app.component.html
|-- app.component.scss
|-- app.component.spec.ts
|-- app-routing.module.ts
|-- app.module.ts

```