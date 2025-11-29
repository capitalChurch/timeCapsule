<template>
   <div class="circle"></div>
</template>

<script>
    export default {
        name: "Loader"
    }
</script>

<style lang="scss">
    @use "sass:math";
    @use "../theme" as *;
    $sizeCircle: 24px;

    @keyframes spin {
        100%{transform: rotate(360deg)}
    }
    .circle{
        width: $sizeCircle;
        height: $sizeCircle;
        border-radius: 50%;
        box-sizing: border-box;
        border: solid math.div($sizeCircle, 6) rgba(0, 0, 0, 0.3);
        border-right-color: $darkColor;
        animation: spin 1s infinite linear;
    }
</style>
