<template>
  <div>
    <titulo :btnVoltar="true" :titulo="professorid != undefined ? 'Professor: ' + professor.nome : 'Todos os Alunos'"/>
    <div v-if="professorid != undefined">
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
        <td class="colPequeno">{{aluno.id}}</td>
        <router-link class="colMedio" :to="`/alunodetalhe/${aluno.id}`" tag="td" style="cursor: pointer">
        {{aluno.nome}} {{aluno.sobrenome}}
        </router-link>
        <td class="colPequeno">
          <button class="btn btn_Vermelho" @click="remover(aluno)">Remover</button>
        </td>
      </tr>
    </tbody>
    <tfoot v-else>
      <tr>
          <td colspan="3" style="text-align: center">
            <h5>Nenhum Aluno Encontrado</h5>
          </td>
        </tr>
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
      professorid: this.$route.params.prof_id,
      professor: {},
      nome: '',
      alunos: []
    }
  },
  mounted() {
    if(this.professorid){
      this.carregarProfessor()
      this.$http
      .get(`http://localhost:5000/api/aluno/ByProfessor/${this.professorid}`)
      .then(res => res.json())
      .then(alunos => this.alunos = alunos)
    } else {
      this.$http
      .get('http://localhost:5000/api/aluno')
      .then(res => res.json())
      .then(alunos => this.alunos = alunos)
    }
  },
  props: {},
  methods: {
    addAluno(){
      let _aluno = {
      nome: this.nome,
      sobrenome: "",
      dataNasc: "",
      professorid: this.professor.id
      }
      this.$http
      .post('http://localhost:5000/api/aluno', _aluno)
      .then(res => res.json())
      .then(aluno => {
        this.alunos.push(aluno);
        this.nome = '';
      })
    },
    remover(aluno){
      this.$http
      .delete(`http://localhost:5000/api/aluno/${aluno.id}`)
      .then(() => {
        let indice = this.alunos.indexOf(aluno);
        this.alunos.splice(indice, 1);
      })
    },
    carregarProfessor(){
      this.$http
      .get('http://localhost:5000/api/professor/' + this.professorid)
        .then((res) => res.json())
        .then(professor => this.professor = professor)
    }
  }
}
</script>

<style scoped>
input{
  width: calc(100% - 195px);
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
  text-shadow: 1px 1px 1px #000;
  border-top: 2px solid #000;
  border-bottom: 2px solid #000;
  margin-bottom: 2px;
}
.colPequeno{
  text-align: center;
  width: 15%;
}
.colMedio{
  text-align: center;
  width: 30%;
}
</style>
