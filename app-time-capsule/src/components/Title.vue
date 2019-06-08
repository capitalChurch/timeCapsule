<template>
    <div class="bigTitle">
        <h1>para meu<br/>futuro!</h1>
    </div>
</template>

<script>
    export default {
        name: "Title"
    }
</script>

<style lang="scss">
    @import "../theme";
    .bigTitle{
        @media only screen and (max-width: $maxWidthSmallDesktop) {
            width: unset !important;
        }
        h1{
            font-family: 'Biotif-Black', sans-serif;
            text-transform: uppercase;
            margin: 40px 0 0;
            font-size: $h1FontSize;
            line-height: $h1FontSize * .9;
            color: $darkColor;

            @media only screen and (max-width: $maxWidthSmallDesktop) {
                font-size: $h1TabletFontSize;
                line-height: $h1TabletFontSize * .9;
            }

            @media only screen and (max-width: $maxWidthMobile){
                font-size: $h1MobileFontSize;
                line-height: $h1MobileFontSize * .9;
            }

            @media only screen and (max-width: $maxWidthMediumMobile) {
                font-size: $h1MediumMobileFontSize;
                line-height: $h1MediumMobileFontSize * .9;
            }
            @media only screen and (max-width: $maxWidthSmallMobile) {
                font-size: $h1SmallMobileFontSize;
                line-height: $h1SmallMobileFontSize * .9;
            }
        }
    }
</style>
