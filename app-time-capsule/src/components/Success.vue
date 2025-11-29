<template>
    <div class="success">
        <Title />
        <div class="bodySuccess">
            <div class="wrapperTitle">
                <div class="title">Nos vemos<br/> em um ano!</div>
                <div class="subtitle">carta enviada com sucesso!</div>
            </div>
            <div class="socialNetworks">
                <a class="socialNetWork" v-for="item in socialNetworks" v-bind:href="item.link">
                    <img :src="getImage(item)" v-bind:title="item.name">
                </a>
            </div>
        </div>
        <Footer />
    </div>
</template>
<script lang="ts">
import {Vue, Component} from 'vue-property-decorator';
    import Title from '@/components/Title.vue';
    import Footer from '@/components/Footer.vue';

    interface socialNetwork {
        name: string;
        link: string;
        filePath: any;
    }
    @Component({
        components: {
            Footer,
            Title,
        },
    })
    export default class Success extends Vue {
        public socialNetworks: socialNetwork[] = [
            {name: 'instagram', filePath: 'instagram.png', link: 'https://www.instagram.com/igrejabcapital/'},
            {name: 'facebook', filePath: 'facebook.png', link: 'https://www.facebook.com/igrejabcapital/'},
            {name: 'twitter', filePath: 'twitter.png', link: 'https://twitter.com/igrejabcapital'},
        ];

        public getImage = (obj: socialNetwork) =>
            require(`../assets/${obj.filePath}`)
    }
</script>
<style lang="scss">
    @use "../theme" as *;
    .success{
        display: flex;
        flex-direction: column;
        justify-content: space-between;
        align-items: center;
        min-height: 100vh;
        >*:last-child{
            width: 100vw;
        }

        @media screen and (min-width: $maxWidthTablet){
            .bigTitle h1{
                font-size: $h1TabletFontSize;
                line-height: $h1TabletFontSize * .9;
            }
        }

        .bodySuccess{
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: space-around;

            @media only screen and (min-width:$maxWidthTablet){
                padding-bottom: 100px;
            }

            color: $primaryColor;

            .title{
                font-family: 'Biotif-Black', sans-serif;
                font-size: $h5FontSize;
                line-height: $h5FontSize * .8;
                text-align: center;
                letter-spacing: .5px;
                padding: 8px 0;
            }
            .subtitle{
                font-family: 'Biotif', sans-serif;
                text-transform: uppercase;
                letter-spacing: 3px;
                padding: 8px 0;
            }
            .socialNetworks{
                margin-top: 60px;
                a{
                    padding: 0 16px;
                    height: 46px;
                    img{
                        width: 30px;
                    }
                    &:nth-child(2){
                        img{
                            transform: translateY(-3px);
                            width: 24px;
                        }
                    }
                }
            }

            @media only screen and (max-width:$maxWidthMobile) {
                .title{
                    font-size: $h5MobileFontSize;
                    line-height: $h5MobileFontSize * .8;
                }
                .subtitle{
                    letter-spacing: 2px;
                }
            }

            @media only screen and (max-width:$maxWidthTablet){
                .socialNetworks a {
                    img {
                        width: 50px;
                    }

                    &:nth-child(2){
                        img{
                            width: 40px;
                        }
                    }
                }
            }
        }
    }
</style>
