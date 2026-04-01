use crate::application::interfaces::tax_calculator::TaxCalculator;
use crate::domain::entities::tax_result::TaxResult;

pub struct SenegalCalculator;

impl TaxCalculator for SenegalCalculator {
    fn calculate(&self, gross: f64) -> TaxResult {
        let ipres = gross * 0.056;
        let css = gross * 0.03;

        let taxable = gross - (ipres + css);

        let income_tax = if taxable <= 300_000.0 {
            0.0
        } else if taxable <= 600_000.0 {
            (taxable - 300_000.0) * 0.10
        } else {
            (300_000.0 * 0.10) + ((taxable - 600_000.0) * 0.20)
        };

        let net = gross - (ipres + css + income_tax);

        TaxResult {
            ipres,
            css,
            income_tax,
            net_salary: net,
        }
    }
}
