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

    @Component({
        components: {
            Form,
            Title,
            Information
        },
    })
    export default class Wrapper extends Vue {}
</script>

<style scoped lang="scss">
    @import "../theme";

    $width: 50vw;
    .wrapper{
        background: $primaryColor;
        display: flex;
        align-items: center;
        flex-direction: column;
        min-width: 100vw;
        min-height: 100vh;

        >*{
            width: $width;
        }

        .body{
            display: flex;
        }
    }
</style>
