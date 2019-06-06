<template>
    <h1>para meu<br/>futuro!</h1>
</template>

<script>
    export default {
        name: "Title"
    }
</script>

<style lang="scss">
    @import "../theme";
    h1{
        font-family: 'Biotif-Black', sans-serif;
        text-transform: uppercase;
        margin: 32px 0;
        font-size: $h1FontSize;
        line-height: $h1FontSize * .9;
        color: $darkColor;

        @media only screen and (max-width: 425px){
            font-size: $h1MobileFontSize;
            line-height: $h1MobileFontSize * .9;
        }

        @media only screen and (max-width: 375px) {
            font-size: $h1MediumMobileFontSize;
            line-height: $h1MediumMobileFontSize * .9;
        }
        @media only screen and (max-width: 340px) {
            font-size: $h1SmallMobileFontSize;
            line-height: $h1SmallMobileFontSize * .9;
        }
    }
</style>
