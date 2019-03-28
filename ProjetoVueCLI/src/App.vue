<template>
  <div id="app">
    <Nav></Nav>
    <div class="marginPrincipal">
      <router-view :key="$route.fullPath"></router-view>
    </div>
  </div>
</template>

<script>
import Alunos from './components/Aluno/Alunos'
import Professor from './components/Professor/Professor'
import Sobre from './components/Sobre/Sobre'
import Nav from './components/_nav/Nav'

export default {
  name: 'app',
  components: {
   Alunos,
   Professor,
   Sobre,
   Nav
  }
}
</script>

<style>
@import url("https://fonts.googleapis.com/css?family=Montserrat");

body{
 background-color: rgb(106, 204, 211);
 font-family: "Montserrat", sans-serif;
 display: grid;
 justify-items: center;
}
body, html{
  margin: 0;
  height: 100%;
}
.marginPrincipal{
  width: 50%;
  margin: auto;

}
#app {
  width: 100%;
}
.btn{
  border: 2px solid rgb(0, 0, 0);
  border-bottom: 4px solid #000;
  border-radius: 7%;
  padding: 8px 12px;
  cursor: pointer;
  font-size: 1.0em;
  background-color: rgb(185, 174, 174);
}
.btn_Vermelho{
  background-color: rgb(180, 57, 57);
}
.btn_Vermelho:hover{
  background-color: rgb(185, 36, 36);
  text-shadow: 1px 1px 1px #000;
  border-top: 2px solid #000;
  border-bottom: 2px solid #000;
  margin-bottom: 2px;
}

table{
  margin: 0px;
  padding: 0px;
  list-style-type: 0;
  width: 100%;
  border-radius: 2%;
  border: 2px solid black;
  background-color: rgb(70, 67, 67);
}
table tr td{
  padding: 20px;
  font-size: 1.3em;
  background-color: #e7d5d5;
  color: #000707;
  border-radius: 4%;
  text-align: center !important;
}
table tr td:hover{
  background-color: #ffffff;
}
table thead th{
  background-color: rgb(185, 226, 236) !important;
  font-size: 1.2em;
  padding: 20px;
  text-align: center !important;
  border-radius: 4%;
}
.colPequeno{
  width: 5%;
}
</style>
