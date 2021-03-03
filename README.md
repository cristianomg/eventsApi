# Events App

# Descrição
Uma simples aplicação utilizando api rest e mvc para registrar e exibir eventos em tempo real

# Objetivo
Desenvolver uma aplicação que recebe eventos, cadastra esses eventos no banco de dados e exibe automaticamente em uma tabela

# Solução aplicada

Para receber os eventos, foi desenvolvida uma aplicação rest utilizando asp net core 3.1, que se comunica via socket com os clientes conectados, enviando uma mensagem quando há um novo registro cadastrado. Essa comunicação é feita através da tecnologia SignalR.

Na parte visual foi desenvolvida uma aplicação em asp net Mvc core 3.1 , que possui uma única página  que ao ser acessada faz uma chamada à api, monta uma tabela na tela e fica escutando a conexão disponibilizada pela api rest. Quando a api envia alguma mensagem para o canal, a apliação mvc recebe esse novo evento cadastrado e insere na tabela que está na tela.

- [x] **.Net Core 3.1**;
- [x] **Microsoft.EntityFrameworkCore**;
- [x] **Npgsql.EntityFrameworkCore.PostgreSql**;
- [x] **Repositories**;
- [x] **FluentValidations**;
- [x] **AutoMapper**;
- [x] **Swagger**;
- [x] **Docker**;
- [x] **Docker Compose**;


# Sumário

1. **[Título](#Sample-Api "Titulo")**
2. **[Descrição](#Descrição "Descrição")**
3. **[Sumário](#Sumário "Sumário")**
4. **[Pre-Requisitos](#Pre-Requisitos "Pre-Requisitos")**
4. **[Instalação](#Instalação "Instalação")**
    1. **[Clone](#clone "Clone")**
    2. **[Inicialização](#inicializacao "Inicializacao")**
    3. 
6. **[Documentação](#Documentação "Documentação")**
6. **[Contatos](#Contatos "Contatos")**

# Pre-Requisitos

- [x] **Docker**;


# Instalação

## Clone
```
https://gitlab.com/cristianomg/junior-analyst.git
```
## Inicialização
Para inicializar entre na pasta do projeto e execute os comandos abaixo:
```cmd
    docker-compose build
    docker-compose up
```
# Documentação

Toda a documentação dos endpoints da api é feita pelo swagger e pode ser acessada pela url abaixo: 
```
http://localhost:5000/index.html
```
# Contatos
cristianomg95@gmail.com
[Linkedin](https://www.linkedin.com/in/cristiano-m-504704160/)
