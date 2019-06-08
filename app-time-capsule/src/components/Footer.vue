<template>
    <div class="footer">
        <div class="body">
            <div class="labels">
                <span>© 2018 Igreja Batista Capital®</span>
                <span>All rights reserved</span>
                <span>Legal</span>
            </div>
            <img src="../assets/logoIgreja.svg" title="Igreja Batista Capital" />
        </div>
    </div>
</template>

<script>
    export default {
        name: "Footer"
    }
</script>

<style scoped lang="scss">
    @import "../theme";
    .footer{
        min-height: 80px;
        background: $darkColor;
        display: flex;
        align-items: center;
        justify-content: center;

        @media only screen and (max-width:$maxWidthTablet){
            padding: 0 $marginOnTablet;
        }

        @media only screen and (max-width:$maxWidthMobile){
            padding: 0 $marginMobile;
        }

        @media only screen and (max-width:$maxWidthMediumMobile){
            padding: 0 $marginMediumMobile;
        }

        .body{
            width: $width;
            display: flex;
            justify-content: space-between;
            align-items: center;

            @media only screen and (max-width: $width){
                width: $widthTablet;
            }
            .labels{
                color: $primaryColor;
                font-family: 'Biotif', sans-serif;
                font-size: $normalFontSize;
                span{
                    padding: 0 16px;
                    &:first-child{
                        padding-left: 0;
                    }
                }
            }

            img{
                transform: translateX(-48px);
                width: 32px;
            }


            @media only screen and (max-width: $maxWidthMobile){
                flex-direction: column-reverse;
                padding: 8px 0;
                .labels {
                    display: flex;
                    flex-direction: column-reverse;
                    align-items: center;
                    span {
                        padding: 8px 16px;
                    }
                }
                img{
                    margin: 24px 0;
                    transform: unset;
                }
            }
        }
    }
</style>
