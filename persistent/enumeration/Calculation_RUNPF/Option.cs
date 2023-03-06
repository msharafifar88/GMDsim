namespace persistent.enumeration.Calculation_RUNPF
{
    public class Option
    {
        public enum PF_ALG
        {

            Newton = 1, Fast_Decoupled_XB = 2, Fast_Decoupled_BX = 3, Gauss_Seidel = 4
        }
        public class PF_Option
        {

            public PF_ALG pf_alg { get; set; } = PF_ALG.Newton;
            public double pf_tol { get; set; } = 1e-8;
            public int pf_max_it { get; set; } = 10;
            public int pf_max_it_fd { get; set; } = 30;
            public int pf_max_it_gs { get; set; } = 1000;

            public bool enforce_q_lims { get; set; } = false;

            public bool pf_dc { get; set; } = false;

        }
        public enum CPF_Parameterization
        {

            natural = 1, arc_length = 2, pseud_arc_length = 3
        }

        public enum CPF_plot_level
        {

            do_not_plot_nose_curve = 0, plot_when_completed = 1, plot_incrementally_at_each_iteration = 2, with_pause_at_each_iteration = 3
        }
        public class CPF_OPTIONS
        {

            public CPF_Parameterization cpf_parameterization { get; set; } = CPF_Parameterization.pseud_arc_length;
            public double cpf_step { get; set; } = 0.05;
            public double cpf_error_tol { get; set; } = 1e-3;
            public double cpf_step_min { get; set; } = 1e-4;
            public double cpf_step_max { get; set; } = 0.2;

            public CPF_plot_level cpf_plot_level { get; set; } = CPF_plot_level.do_not_plot_nose_curve;

            public string cpf_plot_bus { get; set; } = null;
            public string cpf_user_callback { get; set; } = null;
            public string cpf_user_callback_args { get; set; } = null;

        }

        public enum OPF_ALG
        {

            Default_solver = 0, MINOS = 500, MIPS = 540, SC_MIPS = 545
        }

        public enum OPF_flow_lim
        {

            Apparent_pf = 0, Active_pf = 1, Current_magnitude = 2
        }

        public enum OPF_alg_dc
        {

            Default_solver = 0, PIPS = 200, PIPS_sc = 250, IPOPT = 400, CPLEX = 500, MOSEK = 600, GUROBI = 700
        }
        public class OPF_Option
        {

            public OPF_ALG opf_alg { get; set; } = OPF_ALG.Default_solver;
            public double opf_violation { get; set; } = 5e-6;
            public OPF_flow_lim opf_flow_lim { get; set; } = OPF_flow_lim.Active_pf;
            public bool opf_ignore_ang_lim { get; set; } = false;

            public OPF_alg_dc opf_alg_dc { get; set; } = OPF_alg_dc.Default_solver;

        }


        public enum Out_all
        {

            Individual_flags = 1, Do_not_print_progresss = 0, print_all_progresss = 1
        }

        public enum Verbose
        {

            print_no_progresss = 0, print_little_progresss = 1, print_lot_progresss = 2, print_all_progresss = 3
        }
        public enum Out_all_lim
        {

            Individual_flags = -1, no_constraint_info = 0, binding_constraint_info = 1, all_constraint = 2
        }
        public enum Out_v_lim
        {

            print_no = 0, print_binding = 1, print_all = 2
        }
        public class OUTPUT_OPTIONS
        {

            public Verbose verbose { get; set; } = Verbose.print_little_progresss;
            public Out_all out_all { get; set; } = Out_all.Individual_flags;
            public bool out_sys_sum { get; set; } = true;
            public bool out_area_sum { get; set; } = false;
            public bool out_bus { get; set; } = true;
            public bool out_branch { get; set; } = true;
            public bool out_gen { get; set; } = false;
            public Out_all_lim out_all_lim { get; set; } = Out_all_lim.Individual_flags;
            public Out_v_lim ot_v_lim { get; set; } = Out_v_lim.print_binding;

            public int out_line_lim { get; set; } = 1;
            public int out_pg_lim { get; set; } = 1;
            public int out_qg_lim { get; set; } = 1;
            public int return_raw_der { get; set; } = 0;
        }
        public class PDIPM_OPTIONS
        {

            public int pdipm_feastol { get; set; } = 0;
            public double pdipm_gradtol { get; set; } = 1e-6;
            public double pdipm_comptol { get; set; } = 1e-6;
            public double pdipm_costtol { get; set; } = 1e-6;

            public int pdipm_max_it { get; set; } = 150;
            public int scpdipm_red_it { get; set; } = 20;
        }

        public enum Grb_method
        {

            print_simplex = 0, dual_simplex = 1, barrier = 2, concurrent = 3, deterministic = 4
        }
        public class GUROBI_OPTIONS
        {

            public Grb_method grb_method { get; set; } = Grb_method.dual_simplex;
            public int grb_threads { get; set; } = 0;
            public int grb_opt { get; set; } = 0;

        }
    }
}

