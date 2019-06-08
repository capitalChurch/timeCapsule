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
            <button>
                <span>enviar para o futuro!</span>
            </button>
            <span class="hint">Você receberá um email de confirmação.</span>
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

    $radius: 24px;

    .form{
        width: 40%;
        display: flex;
        flex-direction: column;
        background: white;
        padding: 8px 32px 24px;
        margin: 0 32px;
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
                    border-radius: $radius;
                    cursor: pointer;

                    &:hover{
                        background: $darkColorHover;
                        transform: scale(1.01);
                        box-shadow: 0 1px 2px 0 rgba(60,64,67,0.302), 0 1px 3px 1px rgba(60,64,67,0.149);;
                    }

                    &.active{
                        background: $primaryColor;

                        &:hover{
                            background: $primaryColorHover;
                        }
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

            button{
                background: $buttonColor;
                border: none;
                text-transform: uppercase;
                font-family: 'Biotif-Black', sans-serif;
                letter-spacing: 2px;
                padding: 8px;
                cursor: pointer;
                &:focus{
                    outline: none;
                }

                &:hover{
                    background: $buttonColorHover;
                    transform: scale(1.01);
                    box-shadow: 0 1px 2px 0 rgba(60,64,67,0.302), 0 1px 3px 1px rgba(60,64,67,0.149);;
                }
                span{
                    position: relative;
                    top: 2px;
                }
            }

            .hint{
                padding: 4px 0;
                font-family: 'Biotif', sans-serif;
                font-size: 12px;
                font-weight: bold;
                letter-spacing: 1px;
            }

            input{
                border-radius: $radius;
                border: 1px solid $darkColor;
                padding: 8px 16px;
                &:focus{
                    outline: none;
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

        @media only screen and (max-width: $maxWidthSmallDesktop){
            margin: 0;
        }

        @media only screen and (max-width: $maxWidthTablet) {
            width: unset;
            margin: 0 $marginOnTablet;
        }

        @media only screen and (max-width: $maxWidthMobile) {
            margin: 0 $marginMobile;
            padding: 8px 24px;
        }

        @media only screen and (max-width: $maxWidthMediumMobile) {
            margin: 0 $marginMediumMobile;
            >div .label{
                font-size: 12px;
            }
        }
    }
</style>
