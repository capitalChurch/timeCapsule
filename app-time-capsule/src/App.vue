

<template>
  <div id="app">
    <Wrapper v-if="!showSuccess"></Wrapper>
    <Footer v-if="!showSuccess"></Footer>
    <Success v-if="showSuccess"></Success>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import Wrapper from '@/components/Wrapper.vue';
import Footer from '@/components/Footer.vue';
import {successPath} from "@/model/constants";
import Success from '@/components/Success.vue';

@Component({
  components: {
    Success,
    Wrapper,
    Footer
  },
})
export default class App extends Vue {
  public get showSuccess(): boolean{
    return window.location.pathname === successPath;
  }
}
</script>

<style lang="scss">
  @font-face {
    font-family: Biotif;
    src: local("Biotif"),
         url("./assets/fonts/Biotif-Medium.ttf") format('truetype');
  }

  @font-face {
    font-family: 'Biotif-Black';
    src: local('Biotif-Black'),
        url("./assets/fonts/Biotif-Black.ttf") format('truetype');
  }
</style>
