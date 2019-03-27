<template>
  <div>
    <titulo titulo="Alunos"/>
    <div>
      <input type="text" placeholder="Nome do Aluno" v-model="nome" v-on:keyup.enter="addAluno()"/> 
      <button class="btn btn_Input" @click="addAluno()">Adicionar</button>
    </div>
  <table border="1px">
    <thead>
      <th>Mat.</th>
      <th>Nome</th>
      <th>Opções</th>
    </thead>
    <tbody v-if="alunos.length">
      <tr v-for="(aluno, index) in alunos" :key="index">
        <td>{{index+1}}</td>
        <td>{{aluno.nome}}</td>
        <td>
          <button class="btn btn_Vermelho" @click="remover(aluno)">Remover</button>
        </td>
      </tr>
    </tbody>
    <tfoot v-else>
      <p>Nenhum Aluno Encontrado</p>
    </tfoot>
  </table>

  </div>
</template>

<script> 
import Titulo from '../_share/Titulo.vue';

export default {
  components:{
    Titulo
  },
  data() {
    return {
      titulo: 'Alunos',
      nome: '',    
      alunos: []
    }   
  },
  mounted() {  
    this.$http
    .get('http://localhost:3000/alunos')
    .then(res => res.json())
    .then(alunos => this.alunos = alunos)
  },
  props: {
  },
  methods: {
    addAluno(){   
      let _aluno = {
      nome: this.nome, 
      } 
      this.$http
      .post('http://localhost:3000/alunos', _aluno)
      .then(res => res.json())  
      .then(aluno => {
        this.alunos.push(aluno);
        this.nome = '';
      })
    },
    remover(aluno){
      this.$http
      .delete(`http://localhost:3000/alunos/${aluno.id}`)
      .then(() => {
        let indice = this.alunos.indexOf(aluno);
        this.alunos.splice(indice, 1);
      })      
    }
  }
}
</script>

<style scoped>
input{
  border: 2px solid #000;
  border-radius: 3%;
  padding: 20px;
  font-size: 1.3em;
  color: #0f0f0f;
  display: inline;
  margin: 4px;
}
.btn_Input{
  padding: 20px;
  border-bottom: 4px #000 solid;
  font-size: 1.3em;
  background-color: rgb(156, 172, 161);
  display: inline;
}
.btn_Input:hover{
  background-color: rgb(15, 168, 66);
  text-shadow: 2px 1px 1px #000;
  border-top: 2px solid #000;
  border-bottom: 2px solid #000;
  margin-bottom: 2px;
}
</style>
