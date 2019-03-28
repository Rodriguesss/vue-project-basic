import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router);

export default new Router({
    mode: 'history',
    routes: [
        {
            path: '/professores',
            nome: 'Professores',
            component: () => import('./components/Professor/Professor')
        },
        {
            path: '/alunos/:prof_id',
            nome: 'Alunos',
            component: () =>  import('./components/Aluno/Alunos')
        },
        {
            path: '/alunosall',
            nome: 'Alunos',
            component: () =>  import('./components/Aluno/Alunos')
        },
        {
            path: '/alunodetalhe/:aluno_id',
            nome: 'AlunoDetalhe',
            component: () => import('./components/Aluno/AlunoDetalhe')
        },
        {
            path: '/sobre',
            nome: 'Sobre',
            component: () => import('./components/Sobre/Sobre')
        }
    ]
})