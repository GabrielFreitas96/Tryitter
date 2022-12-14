# Tryitter

## Descrição do Projeto
<p align="left">Api desenvolvida com o objetivo de gerenciar  um sistema de posts. O usuário pode se cadastrar, efetuar login e criar os posts.
Chamada de Tryiiter, se refere a uma versão simplificada do Twitter em que os usuários podem crias posts e editar.
A api apresenta um C.R.U.D completo para usuários e posts, apresenta uma relação 1 : N, um usuário pode ter vários posts.
</p>

## Autores
* Gabriel Batista Freitas - https://github.com/GabrielFreitas96
* Leandro de Oliveira - https://github.com/Leandrooc

## Tecnologias utilizadas
<p align="left">Desenvolvido uando o ASP NET Core 6</p>

* C#
* MD5
* .NET Framework 6
* Microsoft Entity Framework Core 
* Xunit
* docker
* Sql Server
* Fluent Assertions
* JWT

## Instalando e Rodando a API
  <summary><strong>.NET 6</strong></summary><br />
  
   >Para a correta execução da api, é necessario que se tenha o .NET instalado na versão 6 e o CLI do Entity Framework.
   
   > Caso não tenha o CLI do entity Framework: Rode o comando dotnet tool install --global dotnet-ef
   
   - Clone a esse repositorio na maquina com o comando git clone "endereço do repositorio"
   - Entre na pasta clonada cd Tryitter
   - Subir o serviço de banco de dados com o docker-compose : docker compose up -d 
   - Entrar na pasta  Tryitter, o caminho deve ser Tryitter/Tryitter
   - Executar as migrations com os comandos:
   - dotnet ef migrations add CreateTables
   - dotnet ef database update
   
   >Caso se deseje utilizar o Visual Studio
   - Abrir a sln denominada de Tryitter.sln
   - Executar o build e instalação dos pacotes
   - Rodar em release
   - UItilizar o Swagger para navegação
   
   >Caso se deseje utilizar o Visual Studio Code (Vs Code)
   -  No caminho Tryitter/Tryitter, rodar o comando dotnet restore para instalar os pacotes
   -  executar o comando dotnet run Tryitter
   -  acessar o navegador no caminho /swagger
   
   http://localhost:60308/swagger/index.html
