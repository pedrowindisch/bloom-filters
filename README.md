[[português]](#bloom-filters) [[english]](#bloom-filters-1)

# Bloom filters

O bloom filter é uma estrutura de dados probabilística com várias aplicações no mundo real. Estruturas de dados probabilísticas abrem mão da precisão em nome da velocidade[0]. 

O bloom filter pode ser utilizado para verificar a presença de um membro em um conjunto. Precisamos ter em mente, ao utilizar essa estrutura de dados (em sua versão padrão), que falsos positivos podem ocorrer; não retornam, em contrapartida, falsos negativos.

## Sobre a implementação

Por baixo dos panos, podemos pensar no bloom filter como uma array de bits, com todos os elementos inicialmente zerados. O bloom filter padrão possui apenas duas operações, que são a inserção de um valor e a verificação da presença de um valor. Outras variantes dessa estrutura permitem operações diferenciadas, como o counting B. F., que possui a opção de remover valores.

A implementação dessas estruturas de dados nesse repositório estão sustentadas por testes automáticos com NUnit.

Esse projeto foi feito com fins de aprendizado; não é preparado para uso em produção.

<hr />

# bloom filters

c#/f# implementation of different types of bloom filters.

this project was created for learning purposes only. it is not intended to be used in production workflows.

## what are bloom filters and how should i use them?

i've written about them [at my blog](https://windisch.com.br) (in portuguese).

<hr />

hmu at/entre em contato comigo via: 
- [pedrowindisch@gmail.com](mailto:pedrowindisch@gmail.com);
- [pedro@windisch.com.br](mailto:pedro@windisch.com.br);
- [linkedin](https://linkedin.com/in/pedrowindisch).