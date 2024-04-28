# ListaCompraWebApp

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 17.3.3.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via a platform of your choice. To use this command, you need to first add a package that implements end-to-end testing capabilities.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page.



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