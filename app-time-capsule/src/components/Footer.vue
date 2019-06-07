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
        height: 80px;
        background: $darkColor;
        display: flex;
        align-items: center;
        justify-content: center;
        .body{
            width: $width;
            display: flex;
            justify-content: space-between;
            align-items: center;

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
        }
    }
</style>
