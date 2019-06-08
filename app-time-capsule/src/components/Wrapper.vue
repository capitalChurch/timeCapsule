<template>
    <div class="wrapper">
        <Title></Title>
        <div class="body">
            <Information></Information>
            <Form></Form>
        </div>
    </div>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import Title from '@/components/Title.vue';
    import Information from '@/components/Information.vue';
    import Form from '@/components/Form.vue';
    import Footer from '@/components/Footer.vue';

    @Component({
        components: {
            Footer,
            Form,
            Title,
            Information
        },
    })
    export default class Wrapper extends Vue {}
</script>

<style scoped lang="scss">
    @import "../theme";

    .wrapper{
        background: $primaryColor;
        display: flex;
        align-items: center;
        flex-direction: column;
        min-height: 100vh;

        >*{
            width: $width;
        }

        .body{
            display: flex;
            margin: 32px 0 48px;

            @media only screen and (max-width: $maxWidthSmallDesktop){
                justify-content: space-around;
            }
            @media only screen and (max-width: $maxWidthTablet) {
                flex-direction: column;
                width: unset;
            }
        }
    }
</style>
