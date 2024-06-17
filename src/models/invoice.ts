export interface Invoice {
    id: number
    number: number
    amount: number
    date: string
    status: 'paid' | 'pending' | 'new'
    invoiceLines: InvoiceLines[]
}

export interface InvoiceLines {
    id: number
    invoiceId: number
    description: string
    quantity: number
    price: number
}