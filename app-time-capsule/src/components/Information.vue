<template>
    <div class="information">
        <div class="title">Escreva uma carta para o futuro ></div>
        <div class="text">
            <p>A igreja que queremos ser começa com a atitude e mudança de seus integrantes. O retorno á santidade se
                inicia em você!</p>
            <p>No espaço ao lado, te incentivamos a escrever quem você deseja ser, na igreja e como igreja, através de
                Jesus, quando copletarmos 50 anos de existência. Dentro de um ano, retornaremos o email para que reflita
                sobre os objetivos traçados e sobre o que fez para chegar até ele.</p>
            <p>Invista no seu relacionamento como Jesus, busque a santidade e permaneça no caminho.</p>
        </div>
    </div>
</template>

<script>
    export default {
        name: "Information"
    }
</script>

<style lang="scss">
    @import "../theme";
    .information {
        width: 35%;
        color: white;
        padding: 0 32px;
        .title {
            font-family: 'Biotif-Black', sans-serif;
            font-size: $h5FontSize;
            line-height: $h5FontSize * .9;
        }

        .text{
            font-family: 'Biotif', sans-serif;
            font-size: $normalFontSize;

            >p{
                margin: 32px 0;
            }
        }
    }
</style>
