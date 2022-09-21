# Start.AspNetCore
Projeto desenvolvido para imersao de desenvolvedores juniors.

## O Projeto
_Case:_ Sistema de controle de vendas

_Premissas do projeto:_ 
- Aplicacao backend
- API REST
- DotNet Core
- CRUD

## Conceitos abordados
### CRUD
CRUD (acrônimo de Create, Read, Update and Delete) que indica as quatro operacoes basicas de um banco de dados:
- C (Create): Operacao de adicionar/inserir novas entradas
- R (Read): Operacao de leitura de entradas existentes
- U (Update): Operacao de atualizacao de entradas existentes
- D (Delete): Operacao de remover entradas existentes

### API
Acrônimo de Application Programming Interface (Interface de Programação de Aplicações) é basicamente um conjunto de rotinas e padrões estabelecidos por uma aplicação, para que outras aplicações possam utilizar as funcionalidades desta aplicação.

Exemplo _Restaurante_:
- Cliente (aplicacao que demanda alguma operacao: website, app mobile, etc.. sao usuarios que desejam acessar informacoes)
- Garcom (API, intermediando os pedidos, levar os pedidos do cliente para a cozinha)
- Cozinha (Server ou servidor, ela recepciona os pedidos, preparar e devolver para o garcom uma resposta ao pedido)
- Pedido (recurso solicitado pelo cliente, podem ser imagens, vídeos, textos, números ou qualquer tipo de dado)

### REST
Um acrônimo para REpresentational State Transfer (Transferência de Estado Representativo). Uma arquitetura de software que impõe condições sobre como uma API deve funcionar.

Principios REST:
- _Uniform Interface_: Indica que o servidor transfere informações em formato-padrão. Recursos sao formatados.
- _Client-server_: Separacao total entre cliente e servidor
- _Stateless_: Na arquitetura REST, a ausência de estado refere-se a um método de comunicação no qual o servidor completa cada solicitação do cliente independentemente de todas as solicitações anteriores. Os clientes podem solicitar recursos em qualquer ordem, e cada solicitação é sem estado ou isolada de outras solicitações. Essa restrição de design da API REST implica que o servidor possa entender completamente e atender à solicitação todas as vezes. 
- _Cacheable_: Exemplo, digamos que você visite um site que tenha imagens comuns de cabeçalho e rodapé em todas as páginas. Toda vez que você visita uma nova página do site, o servidor deve reenviar as mesmas imagens. Para evitar isso, o cliente armazena em cache ou armazena essas imagens após a primeira resposta e, em seguida, usa as imagens diretamente do cache. 
- _Layered System_: Em uma arquitetura de sistema em camadas, o cliente pode se conectar a outros intermediários autorizados entre o cliente e o servidor e ainda receber respostas do servidor. Os servidores também podem passar solicitações para outros servidores. Você pode projetar seu serviço da Web RESTful para ser executado em vários servidores com diversas camadas, como segurança, aplicação e lógica de negócios, trabalhando juntos para atender às solicitações do cliente. Essas camadas permanecem invisíveis para o cliente.
- _Code on demand (opcional)_: Por exemplo, quando você preenche um formulário de registro em qualquer site, seu navegador imediatamente destaca os erros cometidos, como números de telefone incorretos. Ele pode fazer isso devido ao código enviado pelo servidor.

### RESTful
RESTful é a aplicação dos principios REST.