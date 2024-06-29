import type { InvoiceLines } from "./invoice-lines"

export interface Invoice {
    id?: string
    number: number
    amount: number
    date: string
    status: 'draft' | 'pending' | 'paid' | 'cancelled'
    invoiceLines: InvoiceLines[]
}

