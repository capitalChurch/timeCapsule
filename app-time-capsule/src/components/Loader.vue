<template>
   <div class="circle"></div>
</template>

<script>
    export default {
        name: "Loader"
    }
</script>

<style lang="scss">
    @import "../theme";
    $sizeCircle: 24px;

    @keyframes spin {
        100%{transform: rotate(360deg)}
    }
    .circle{
        width: $sizeCircle;
        height: $sizeCircle;
        border-radius: 50%;
        box-sizing: border-box;
        border: solid $sizeCircle/6 rgba(0, 0, 0, 0.3);
        border-right-color: $darkColor;
        animation: spin 1s infinite linear;
    }
</style>
