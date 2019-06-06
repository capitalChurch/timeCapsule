<template>
    <div class="form">
        <div>
            <span class="label">sua futura carta</span>
            <textarea rows="10" placeholder="Querido(a)."></textarea>
        </div>
        <div>
            <span class="label">entregar</span>
            <div class="options">
                <div class="option">
                    <span>1 ano</span>
                </div>
            </div>
        </div>
        <div>
            <span class="label">essa carta será</span>
            <div class="options">
                <div class="option">
                    <span>privada</span>
                </div>
                <div class="option active">
                    <span>pública</span>
                </div>
            </div>
        </div>
        <div>
            <span class="label">seu endereço de e-mail</span>
            <input type="text">
        </div>
        <div>
            <button>enviar para o futuro!</button>
            <span class="hint">Vodê receberá um email de confirmação.</span>
        </div>
    </div>
</template>

<script>
    export default {
        name: "Form"
    }
</script>

<style scoped lang="scss">
    @import "../theme";
    .form{
        width: 40%;
        display: flex;
        flex-direction: column;
        background: white;
        padding: 8px 32px 24px;
        font-family: 'Biotif-Black', sans-serif;

        >div{
            display: flex;
            flex-direction: column;
            margin: 8px 0;

            color: $darkColor;

            .label{
                letter-spacing: 2px;
                text-transform: uppercase;
                font-size: 14px;
                padding: 8px 0;
            }

            .options{
                display: flex;
                padding: 0 8px;

                &:first-child{
                    padding-left: 0;
                }
                .option{
                    margin: 0 16px;
                    padding: 8px 16px;
                    background: $darkColor;
                    color: white;
                    text-transform: uppercase;
                    font-size: 12px;
                    letter-spacing: 2px;
                    border-radius: 24px;

                    &.active{
                        background: $primaryColor;
                    }

                    span{
                        position: relative;
                        top: 2px;
                    }
                    &:first-child{
                        margin: 0;
                    }
                }
            }

            textarea{
                resize: none;
                padding: 8px 16px;
                font-family: 'Biotif-Black', sans-serif;
                border: 1px solid $darkColor;
                border-left: none;
                border-right: none;

                &:focus{
                    outline: none;
                }
                &::placeholder{
                    color: $darkColor;
                    font-size: 10px;
                    vertical-align: middle;
                    padding: 0 4px;
                }
            }
        }
    }
</style>
