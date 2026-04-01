use crate::domain::entities::tax_result::TaxResult;

pub trait TaxCalculator {
    fn calculate(&self, gross: f64) -> TaxResult;
}
