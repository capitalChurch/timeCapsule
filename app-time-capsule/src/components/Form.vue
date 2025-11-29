<template>
    <div class="form">
        <div>
            <span class="label">sua futura carta</span>
            <textarea rows="10" placeholder="Querido(a)." v-model="objToSend.text"></textarea>
        </div>
        <div>
            <span class="label">entregar</span>
            <div class="options">
                <div class="option"
                     v-for="year in optionsYears"
                     v-on:click="chooseOptionYearToSend(year)"
                     v-bind:class="{active: optionYearToSendActive(year)}">
                    <span>{{year.label}}</span>
                </div>
            </div>
        </div>
        <div>
            <span class="label">essa carta será</span>
            <div class="options">
                <div class="option"
                     v-for="type in optionsTypeMessage"
                     v-on:click="chooseOptionTypeLetter(type)"
                     v-bind:class="{active: optionTypeLetterActive(type)}">
                    <span>{{type.label}}</span>
                </div>
            </div>
        </div>
        <div>
            <span class="label">seu endereço de e-mail</span>
            <input type="text" v-model="objToSend.email">
        </div>
        <div>
            <button v-on:click="sendMessage()"
                    v-bind:disabled="formSubmitted"
                    v-bind:class="{disabled: formSubmitted}">
                <span>enviar para o futuro!</span>
            </button>
            <span class="hint">Você receberá um email de confirmação.</span>
            <span class="withError" v-if="formWithError && !formSubmitted">Houve um problema no servidor, favor informar a comunicação da Igreja Capital.</span>
        </div>
        <div class="loader" v-if="formSubmitted">
            <Loader></Loader>
        </div>
    </div>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator';
    import {Message} from '@/model/types/Message';
    import {TypeMessageEnum} from '@/model/types/TypeMessageEnum';
    import {saveMessage} from '@/model/model';
    import Loader from '@/components/Loader.vue';
    import {Option} from '@/model/types/Option';
    import {successPath} from '@/model/constants';

    @Component({
        components: {Loader},
    })
    export default class Form extends Vue {
        public readonly optionsYears: Array<Option<number>> = [
            {id: 1, label: '1 Ano'},
            // {id: 3, label: '3 Ano'},
            // {id: 5, label: '5 Ano'},
        ];

        public readonly optionsTypeMessage: Array<Option<TypeMessageEnum>> = [
            {id: TypeMessageEnum.TypeMessagePrivate, label: 'Privada'},
            {id: TypeMessageEnum.TypeMessagePublic, label: 'Pública'},
        ];

        public objToSend: Message = {
            dateRegister: new Date(),
            email: '',
            text: '',
            type: TypeMessageEnum.TypeMessagePublic,
            yearsToSend: 1,
        };

        public formWithError: boolean = false;
        public formSubmitted: boolean = false;

        public optionYearToSendActive = (obj: Option<number>): boolean =>
            this.objToSend.yearsToSend === obj.id

        public optionTypeLetterActive = (obj: Option<TypeMessageEnum>): boolean =>
            this.objToSend.type === obj.id

        public chooseOptionYearToSend = (obj: Option<number>): void => {
            this.objToSend.yearsToSend = obj.id;
        }

        public chooseOptionTypeLetter = (obj: Option<TypeMessageEnum>): void => {
            this.objToSend.type = obj.id;
        }

        public sendMessage(): void {
            this.formSubmitted = true;

            saveMessage(this.objToSend, () => window.location.assign(successPath),
                (err) => {
                    this.formWithError = true;
                    this.formSubmitted = false;
                    console.error(err);
                });
        }
    }
</script>

<style scoped lang="scss">
    @use "../theme" as *;

    $radius: 24px;

    .form{
        width: 40%;
        display: flex;
        flex-direction: column;
        background: white;
        padding: 8px 32px 24px;
        margin: 0 32px;
        font-family: 'Biotif-Black', sans-serif;

        .loader{
            align-items: center;
        }
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

                &:focus{
                    outline: none;
                }

                &.disabled{
                    background: $buttonColorHover;
                }

                &:not(.disabled){
                    cursor: pointer;
                    &:hover{
                        background: $buttonColorHover;
                        transform: scale(1.01);
                        box-shadow: 0 1px 2px 0 rgba(60,64,67,0.302), 0 1px 3px 1px rgba(60,64,67,0.149);;
                    }
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


            .withError{
                color: #a50000;
                border: 1px solid red;
                border-radius: 4px;
                padding: 8px 16px;
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
                font-family: 'Biotif', sans-serif;
                border: 1px solid $darkColor;
                border-left: none;
                border-right: none;

                &:focus{
                    outline: none;
                }
                &::placeholder{
                    color: $darkColor;;
                    font-family: 'Biotif-Black', sans-serif;
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
