# SENAI Backend Challenge 01.01 - Lucas Henrique Russo do Nascimento

Esta é a entrega do desafio "SENAI Backend Challenge 01.01".

*Candidato:*

>Nome: Lucas Henrique Russo do Nascimento
>
>Email: lucnascimento98@gmail.com

# Informações sobre os entregáveis

Todos os endpoints foram realizados. Cada um possui sua documentação swagger em 
>[endereço_ip]:[porta] /swagger

sendo [`endereço_ip`] e [`porta`] os dados da máquina onde a API está em rodando
## appsettings.local.json

Usualmente este arquivo não seria commitado junto ao restante do projeto. Porém neste caso isso se fez necessario pois ele possui uma string que gera/verifica os Tokens JWT. É sabido que esta seria uma informação sigilosa numa situação real de entrega de projeto e, portanto, seria compartilhado de outra maneira.

## Endpoints com autorização
Alguns endpoints necessitam de autorização. São eles `POST/Event` , `PUT/Event/{Id}` e `DEL/Event/{Id}` 

A autorização é concedida atraves do endpoint de autenticação em `POST/Authentication`

Este endpoint gera um Token JWT, que possui as informações de autorização e que deve ser passado pelo header para as outras requisições que necessitarem dele.

Para facilitar os testes destes endpoints especificos estou entregando um arquivo **.postman_collection.json** que tem esses endpoints pré-configurados com a autorização na aba `Authorization`, basta colar Token no campo 'Token'. Este arquivo também possui o restante dos endpoints que nao precisam de autorização.

***Lembrete:*** Quando usar o arquivo do postman, trocar o endereço IP e porta para o endereço e porta adequados.

## Parametros de data e hora nos endpoints

Alguns endpoints precisam de um input de data e/ou hora. São eles `POST/Event` , `GET/Event` e `PUT/Event/{Id}`.

Esses inputs devem seguir o formato:

>Data: "dd/MM/aaaa"

>Hora: "hh:mm" ou "hh:mm:ss"

## Endpoint de Seeding

O endpoint e seeding do banco foi feito com a biblioteca Bogus (https://github.com/bchavez/Bogus).
Os usuarios gerados sao usuarios aleatórios, assim como os eventos.
Os nomes de cada evento são sentencas *Lorem Ipsun* aleatórias.
As datas de cada evento são randomizadas entre 01/01/2000 e 31/12/2022.

-----------------------------------------------