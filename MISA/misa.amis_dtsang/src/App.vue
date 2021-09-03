<template>
  <div id="app">
    <NavBar />
    <Header />
    <Content />
  </div>
</template>

<script>
import NavBar from './components/layout/TheMenu.vue'
import Header from './components/layout/TheHeader.vue'
import Content from './components/layout/TheContent.vue'
export default {
  name: 'App',
  components: {
    NavBar, Header,Content
  }
}
</script>

<style>
@import url('css/FontFamily.css');
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  width: 100vw;
  height: 100vh;
  position: relative;
}

</style>
