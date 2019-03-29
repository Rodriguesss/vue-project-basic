<template>
  <div v-if="!loading">
    <titulo :titulo="`Aluno: ${aluno.nome}`" :btnVoltar="!visualizando">
      <button v-show="visualizando" class="btn btn-editar" @click="editar()">Editar</button>
    </titulo>

    <table border="1px">
      <tbody>
        <tr>
          <td class="colPequeno">Matrícula:</td>
          <td>
            <label class="id">{{aluno.id}}</label>
          </td>
        </tr>

        <tr>
          <td class="colPequeno">Nome:</td>
          <td>
            <label v-if="visualizando">{{aluno.nome}}</label>
            <input v-else v-model="aluno.nome" type="text">
          </td>
        </tr>

        <tr>
          <td class="colPequeno">Sobrenome:</td>
          <td>
            <label v-if="visualizando">{{aluno.sobrenome}}</label>
            <input v-else v-model="aluno.sobrenome" type="text">
          </td>
        </tr>

        <tr>
          <td class="colPequeno">Data Nascimento:</td>
          <td>
            <label v-if="visualizando">{{aluno.dataNasc}}</label>
            <input v-else v-model="aluno.dataNasc" type="text">
          </td>
        </tr>

        <tr>
          <td class="colPequeno">Professor:</td>
          <td>
            <label v-if="visualizando">{{aluno.professor.nome}}</label>
            <select v-else v-model="aluno.professor.id">
              <option
                v-for="(professor, index) in professores"
                :key="index"
                :value="professor.id"
              >{{professor.nome}}</option>
            </select>
          </td>
        </tr>
      </tbody>
    </table>

    <div>
      <div>
        <button class="btn btn-salvar" @click="salvar(_aluno)">Salvar</button>
        <button class="btn btn-cancelar" @click="cancelar()">Cancelar</button>
      </div>
    </div>
  </div>
</template>

<script>
import Titulo from "../_share/Titulo";

export default {
  components: {
    Titulo
  },
  data() {
    return {
      professores: [],
      aluno: {},
      id: this.$route.params.aluno_id,
      visualizando: true,
      loading: true
    };
  },
  mounted() {
    this.carregarProfessor();
  },
  methods: {
    carregarProfessor() {
      this.$http
        .get("http://localhost:5000/api/professor")
        .then(res => res.json())
        .then(prof => {
          this.professores = prof;
          this.carregarAluno();
          });
    },
    carregarAluno() {
      this.$http
        .get(`http://localhost:5000/api/aluno/${this.id}`)
        .then(res => res.json())
        .then(aluno => {
          this.aluno = aluno;
          this.loading = false;
          });
    },
    editar() {
      this.visualizando = !this.visualizando;
    },
    salvar(aluno) {
      let _alunoEditar = {
        id: this.aluno.id,
        nome: this.aluno.nome,
        sobrenome: this.aluno.sobrenome,
        dataNasc: this.aluno.dataNasc,
        professorid: this.aluno.professor.id
      }
      this.$http
        .put(`http://localhost:5000/api/aluno/${this.aluno.id}`, _alunoEditar)
        .then(res => res.json())
        .then((aluno) = this.aluno = aluno);

    },
    cancelar() {
      this.visualizando = !this.visualizando;
    }
  }
};
</script>

<style scoped>
.colPequeno {
  width: 20%;
  background-color: rgb(255, 255, 255);
  font-weight: bold;
}
input,
select {
  text-align: left;
  margin: 0px;
  padding: 0px;
  font-size: 0.9em;
  border-radius: 5px;
  font-family: Montserrat;
  border: 1px solid silver;
  background-color: rgb(243, 245, 245);
  width: 95%;
}
select {
  height: 38px;
  width: 100%;
}
.btn-editar {
  float: right;
  margin-right: 5px;
  background-color: rgb(185, 174, 174);
}
.btn-editar:hover {
  background-color: rgb(209, 233, 76);
  text-shadow: 1px 1px 1px #000;
  border-bottom: 2px solid #000;
}
.btn-salvar {
  margin-top: 5px;
  margin-right: 3px;
}
.btn-salvar:hover {
  background-color: rgb(83, 221, 90);
  text-shadow: 1px 1px 1px #000;
  border-bottom: 2px solid #000;
}
.btn-cancelar:hover {
  background-color: rgb(223, 27, 27);
  text-shadow: 1px 1px 1px #000;
  border-bottom: 2px solid #000;
}
</style>